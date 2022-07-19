using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Xsl;
using Application = System.Windows.Forms.Application;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineImport {

	/// <summary>
	/// ImportWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ImportWindow:Window {

		/// <summary>
		/// インポート対象のKeyMapファイルのパスを指定してImportWindow クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="fileName">インポート対象となるKeyMapファイルのパス。</param>
		internal ImportWindow() => this.InitializeComponent();

		#region プロパティ

		/// <summary>
		/// インポート対象のKeyMapファイルのパスを取得または設定します。
		/// </summary>
		private string FileName {
			get;
			set;
		}

		/// <summary>
		/// KeyMapファイルのパスを取得または設定します。
		/// </summary>
		private string OutputPath {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// KeyMapファイルに含まれるSVGファイルのリストを取得または設定します。
		/// </summary>
		private string[] SvgFileList {
			get;
			set;
		}

		/// <summary>
		/// 処理中に発生した例外を取得または設定します。
		/// </summary>
		private Exception Exception {
			get;
			set;
		} = null;

		#endregion

		#region メソッド

		/// <summary>
		/// 親ウィンドウの位置を基準にウィンドウを開き、新しく開かれたウィンドウが閉じられる場合のみ返ります。
		/// </summary>
		/// <param name="piarent">基準にする親ウィンドウ。</param>
		/// <returns>インポートしたKeyMapのパス。</returns>
		internal void ShowDialog(Window piarent) {

			System.Windows.Forms.DialogResult result;
			using(var dialog = new OpenFileDialog()) {
				dialog.Filter=App.Language.ImportKeyMap.DialogFilter;
				piarent.Topmost=false;
				result=dialog.ShowDialog();
				this.FileName=dialog.FileName;
				piarent.Topmost=true;
			}

			if(result!=System.Windows.Forms.DialogResult.OK) {
				throw new KeyMapUNZipException();
			}

			//KeyMapファイルの展開先パスを設定
			try {
				this.OutputPath=Path.Combine(Application.LocalUserAppDataPath,Path.GetFileNameWithoutExtension(this.FileName));
			} catch(Exception ex) {
				throw new KeyMapUNZipException(App.Language.ImportKeyMap.CannotOpenZipFile,ex);
			}

			//親ウィンドウの位置からウィンドウの表示位置を算出
			if(piarent!=null) {
				this.Top=piarent.Top+((piarent.Height-this.Height)/2);
				this.Left=piarent.Left+((piarent.Width-this.Width)/2);
			}

			//インポートプログレスウィンドウを表示
			_=this.ShowDialog();

			if(this.Exception==null) {

				//定義リスト更新
				App.DefineManager.Update();

				App.DefineManager.Load(this.OutputPath);

				_=MessageBox.Show(piarent,App.Language.ImportKeyMap.Successful,App.Language.ImportKeyMap.Successful,MessageBoxButton.OK,MessageBoxImage.None);
				return;
			} else if(this.Exception is OldClearCancelException) {
				_=MessageBox.Show(this,App.Language.ImportKeyMap.OldClearCancel,App.Language.ImportKeyMap.OldClearCancel,MessageBoxButton.OK,MessageBoxImage.Information);
			} else if(this.Exception is KeyMapUNZipException) {
				_=MessageBox.Show(piarent,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
			} else if(this.Exception is XamlConvertException) {
				_=MessageBox.Show(piarent,App.Language.ImportKeyMap.CannotXamlConvert,App.Language.ImportKeyMap.CannotXamlConvert,MessageBoxButton.OK,MessageBoxImage.Error);
			}

			throw this.Exception;
		}

		/// <summary>
		/// ウィンドウのコンテンツがレンダリングされた後に発生するイベントのイベントハンドラメソッド。
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベント データを格納しているブジェクト。</param>
		private void Window_ContentRendered(object sender,EventArgs e) {

			//同一名のキーマップ定義を削除
			if(Directory.Exists(this.OutputPath)) {
				var result=MessageBox.Show(this,App.Language.ImportKeyMap.OldClearQ,App.Language.ImportKeyMap.OldClearQ,MessageBoxButton.OKCancel,MessageBoxImage.Question);
				if(result==MessageBoxResult.Cancel) {
					this.Exception=new OldClearCancelException();
					this.Close();
				}

				Directory.Delete(this.OutputPath,true);
			}

			_=Task.Run(() => {
				try {

					//KeyMapファイルを展開
					this.UnZip();

					//SVGファイルのリストを取得
					this.GetSvgList();

					//SVGファイルをXAMLファイルに変換
					this.ConvertSvgToXaml();

					//ウィンドウをクローズ
					this.Dispatcher.Invoke(() => this.Close());

				} catch(Exception ex) when(ex is KeyMapUNZipException|ex is XamlConvertException) {
					try {
						Directory.Delete(this.OutputPath,true);
					} catch(Exception exe) when(exe is ArgumentException|exe is DirectoryNotFoundException|exe is IOException|exe is PathTooLongException|exe is UnauthorizedAccessException)  {
					}

					this.Exception=ex;
					this.Dispatcher.Invoke(() => this.Close());
				}
			});
		}

		/// <summary>
		/// KeyMapファイルを展開します。
		/// </summary>
		private void UnZip() {

			FileStream fs = null;
			ZipArchive zipArchive = null;
			try {

				//KeyMapファイルをオープン
				fs=new FileStream(this.FileName,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				zipArchive=new ZipArchive(fs);
				fs=null;

				//KeyMapファイルとして妥当な構成かチェック
				if(zipArchive.GetEntry("KeyMap.xml")==null) {
					throw new KeyMapUNZipException(App.Language.ImportKeyMap.XmlNotFound);
				}

				//KeyMapファイルを展開
				var message = string.Format(CultureInfo.CurrentCulture,App.Language.ImportKeyMap.UNZipProgressMessage,new object[] { "{0}",zipArchive.Entries.Count });
				for(var entryCounter = 0;entryCounter<zipArchive.Entries.Count;entryCounter++) {

					//プログレスバーを更新
					this.Dispatcher.Invoke(() => {
						this.StatusLabel.Content=string.Format(CultureInfo.CurrentCulture,message,new object[] { entryCounter });
						this.StatusProgress.Value=50d*entryCounter/zipArchive.Entries.Count;
					});

					//出力先パスを生成
					var outputPath = Path.Combine(this.OutputPath,zipArchive.Entries[entryCounter].FullName);

					//展開先ディレクトリを作成
					_=Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

					//ファイルを展開
					zipArchive.Entries[entryCounter].ExtractToFile(outputPath);

				}
			} catch(Exception ex) {
				throw new KeyMapUNZipException(App.Language.ImportKeyMap.CannotOpenZipFile,ex);
			} finally {
				zipArchive?.Dispose();
				fs?.Dispose();
			}
		}

		/// <summary>
		/// SVGファイルのリストを取得します。
		/// </summary>
		private void GetSvgList() {

			//プログレスバーを更新
			_=this.Dispatcher.Invoke(() => this.StatusLabel.Content=App.Language.ImportKeyMap.SvgSearchMessage);

			//SVGファイルのリストを取得
			this.SvgFileList=this.GetSvgList(this.OutputPath,new List<string>()).ToArray();
		}

		/// <summary>
		/// SVGファイルのリストを取得します。
		/// </summary>
		/// <param name="targetPath">SVGファイルの検索対象となるパス。</param>
		/// <param name="list">SVGファイルのリスト。</param>
		/// <returns></returns>
		private List<string> GetSvgList(string targetPath,List<string> list) {
			try {

				//サブディレクトリを処理
				foreach(var dir in Directory.EnumerateDirectories(targetPath)) {
					_=this.GetSvgList(dir,list);
				}

				//ディレクトリ内にあるSVGファイルを取得
				list.AddRange(Directory.EnumerateFiles(targetPath,"*.svg"));

				return list;
			} catch(Exception ex) {
				throw new XamlConvertException(ex.Message,ex);
			}
		}

		/// <summary>
		/// SVGファイルをXAMLファイルにコンバートします。
		/// </summary>
		private void ConvertSvgToXaml() {
			try {

				//XSLTをロード
				var myXslTransform = new XslCompiledTransform();
				myXslTransform.Load(XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineImport.svg2xaml.xsl"),new XmlReaderSettings() {
					ConformanceLevel=ConformanceLevel.Document,
					DtdProcessing=DtdProcessing.Ignore
				}));

				var message = string.Format(CultureInfo.CurrentCulture,App.Language.ImportKeyMap.Svg2XamlConvertMessage,new object[] { "{0}",this.SvgFileList.Length });
				for(var listCounter = 0;listCounter<this.SvgFileList.Length;listCounter++) {

					//プログレスバーを更新
					this.Dispatcher.Invoke(() => {
						this.StatusLabel.Content=string.Format(CultureInfo.CurrentCulture,message,new object[] { listCounter });
						this.StatusProgress.Value=(50d*listCounter/this.SvgFileList.Length)+50;
					});

					//SVGファイルをロードして変換結果をXAMLファイルに出力
					using(var writer = new XmlTextWriter(this.SvgFileList[listCounter]+".xaml",Encoding.UTF8))
					using(var xmlReader = XmlReader.Create(this.SvgFileList[listCounter],new XmlReaderSettings() {
						ConformanceLevel=ConformanceLevel.Document,
						DtdProcessing=DtdProcessing.Ignore
					})) {
						myXslTransform.Transform(xmlReader,null,writer);
						writer.Flush();
					}
				}
			} catch(Exception ex) {
				throw new XamlConvertException(ex.Message,ex);
			}
		}

		#endregion

	}
}