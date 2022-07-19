using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader;
using WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker;
using Application = System.Windows.Forms.Application;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1 {

	/// <summary>
	/// KeyMap定義のマネジメントに必要な処理を提供します。
	/// </summary>
	class DefineManager:IDisposable {

		/// <summary>
		/// KeyMap定義が格納されたディレクトリのパスリストを取得します。
		/// </summary>
		internal string[] DirList {
			get;
		} = new string[] {
			Application.LocalUserAppDataPath,
			Path.Combine(Environment.CurrentDirectory,"Config")
		};

		/// <summary>
		/// KeyMap定義のファイルリストを取得または設定します。
		/// </summary>
		internal ReadOnlyDictionary<string,string> FileList {
			get;
			private set;
		}

		/// <summary>
		/// キーボードを表示するウィンドウのインスタンスを取得または設定します。
		/// </summary>
		internal MainWindow KeybordWindow {
			get;
			set;
		}

		/// <summary>
		/// キーボードを表示するグリッドのインスタンスを取得または設定します。
		/// </summary>
		internal Grid KeybordGrid {
			get;
			set;
		}

		/// <summary>
		/// キーマップリストを取得または設定します。
		/// </summary>
		private KeyMapList KeyMapList {
			get;
			set;
		}

		/// <summary>
		/// KeyMap定義ファイルリストを更新します。
		/// </summary>
		internal void Update() {
			try {
				var result = new Dictionary<string,string>();
				foreach(var basePath in this.DirList) {
					foreach(var subDir in Directory.EnumerateDirectories(basePath)) {
						if(!File.Exists(Path.Combine(subDir,"KeyMap.xml"))) {
							continue;
						}

						result.Add(subDir,new DirectoryInfo(subDir).Name);
					}
				}

				this.FileList=new ReadOnlyDictionary<string,string>(result);
			} catch(Exception) {
				throw new LoadException();
			}	
		}

		/// <summary>
		/// KeyMap定義ファイルを設定ファイルからパスを取得しロードします。
		/// </summary>
		/// <param name="save">KeyMap定義ファイルのロード成功時に保存するかを示す値。</param>
		/// <returns>ロードの成否を示す値。</returns>
		internal void Load(bool save = true) {

			foreach(var keyMapPath in App.DefineManager.FileList.Keys) {
				if(App.Config.KeyMapSetPath==keyMapPath) {
					try {
						this.Load(keyMapPath,save);
						return;
					} catch(LoadException) {
					}
				}
			}

			string path;
			try {
				path=Path.Combine(new string[] { Environment.CurrentDirectory,"Config","Theias config for Minecraft building" });
			} catch(ArgumentException) {
				throw new LoadException();
			}

			this.Load(path,false);

		}

		/// <summary>
		/// KeyMap定義ファイルをロードします。
		/// </summary>
		/// <param name="configPath">KeyMap定義ファイルのパス。</param>
		/// <param name="save">KeyMap定義ファイルのロード成功時に設定ファイル保存するかを示す値。</param>
		/// <returns>ロードの成否を示す値。</returns>
		internal void Load(string configPath,bool save=true) {
			if(this.KeybordWindow==null) {
				throw new LoadException();
			}

			try {

				//KeyMap定義ファイルをロード
				this.LoadCore(configPath);

				if(save) {

					//設定ファイルにパスを設定
					App.Config.KeyMapSetPath=configPath;

					//設定ファイルを保存
					App.Config.Save();

				}

				return;
			} catch(CheckException ex) {
				var message = new StringBuilder();
				_=message.Append(ex.Message);
				foreach(var innnerException in ex.InnnerExceptionList) {
					_=message.Append(Environment.NewLine);
					_=message.Append(innnerException.Message);
					_=message.Append(string.Format(CultureInfo.CurrentCulture,App.Language.KeyMapSetLoder.ErrorMessages.ErrorPoint,new object[] { innnerException.ConfigPath??string.Empty,innnerException.KeyMapName??string.Empty,innnerException.RowNumber==-1 ? string.Empty : innnerException.RowNumber.ToString(CultureInfo.CurrentCulture),innnerException.KeyNumber==-1 ? string.Empty : innnerException.KeyNumber.ToString(CultureInfo.CurrentCulture),innnerException.InputIndex==-1 ? string.Empty : innnerException.InputIndex.ToString(CultureInfo.CurrentCulture),innnerException.Value??string.Empty }));
				}

				_=MessageBox.Show(this.KeybordWindow,message.ToString(),App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
			} catch(ArgumentNullException ex) {
				_=MessageBox.Show(this.KeybordWindow,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss+Environment.NewLine+ex.Message,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
			} catch(LoadException) {
				_=MessageBox.Show(this.KeybordWindow,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
			} catch(ArgumentException) {
				_=MessageBox.Show(this.KeybordWindow,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
			} catch(SaveException ex) {
				_=MessageBox.Show(this.KeybordWindow,App.Language.Config.FalidSave+Environment.NewLine+ex.Message,App.Language.Config.FalidSave,MessageBoxButton.OK,MessageBoxImage.Error);
			}

			throw new LoadException();

		}

		/// <summary>
		/// KeyMap定義ファイルをロードします。
		/// </summary>
		/// <param name="configPath">KeyMap定義ファイルのパス。</param>
		private void LoadCore(string configPath) {

			//KeyMap定義ファイルをロード
			var keyMapSet = KeyMapSet.Load(configPath);

			//KeyMap定義の継承処理
			keyMapSet.BaseKeyMapLoad(this.DirList,this.FileList);

			//KeyMap定義をチェック
			keyMapSet.Check();

			//KeyMap定義にオートコンプリートを実行
			keyMapSet.AutoComplete();

			//KeyMap定義からKeyMapListを作成
			var newKeyMapList = KeyMapList.MakeKeyMapList(keyMapSet,this.KeybordGrid);

			//キーボードを表示するウィンドウのサイズを設定
			this.KeybordWindow.SetWindowSize(newKeyMapList.Width,newKeyMapList.Height);

			//直前にロードしたKeyMap定義の画像読み込みを停止
			this.KeyMapList?.KeyTopUpdataCancelAsync();

			//KeyMap定義の画像読み込みを開始
			newKeyMapList.LoadKeyTopImage();

			//デフォルトキーマップを設定
			newKeyMapList.TransitionDefaultKeyMap();

			//曲全にロードしたKeyMap定義のKeyMapを削除
			this.KeyMapList?.RemoveKeyMap();

			this.KeyMapList=newKeyMapList;
		}

		/// <summary>
		/// アンマネージ リソースの解放またはリセットに関連付けられているアプリケーション定義のタスクを実行します。
		/// </summary>
		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// アンマネージ リソースの解放またはリセットに関連付けられているアプリケーション定義のタスクを実行します。
		/// </summary>
		/// <param name="disposing">マネージリソースを開放するかを示す値。</param>
		protected virtual void Dispose(bool disposing) {
			if(disposing) {
				this.KeyMapList.KeyTopUpdataCancelAsync();
			}
		}

		/// <summary>
		/// デストラクタ
		/// </summary>
		~DefineManager() {
			this.Dispose(false);
		}
	}
}