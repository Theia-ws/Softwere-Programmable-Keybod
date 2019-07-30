using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// キーマップセットデータを格納するクラス。
	/// </summary>
	[Serializable]
	[XmlRoot("keyMapSet")]
	public class KeyMapSet {

		#region プロパティ

		/// <summary>
		/// ウィンドウの高さを取得または設定します。
		/// </summary>
		[XmlAttribute("windowHeight")]
		public int WindowHeight {
			get;
			set;
		} = -1;

		/// <summary>
		/// ウィンドウの幅を取得または設定します。
		/// </summary>
		[XmlAttribute("windowWidth")]
		public int WindowWidth {
			get;
			set;
		} = -1;

		/// <summary>
		/// キーマップセットの対象となる実行ファイルのパスを取得します。（将来のため予約され現在は未使用です。）
		/// </summary>
		[XmlElement("targetExe")]
		public TargetExeCollection TargetExe {
			get;
		} = new TargetExeCollection();

		/// <summary>
		/// キーマップデータのソース情報を取得または設定します。
		/// </summary>
		[XmlElement("keyMap")]
		public KeyMapCollection KeyMapSource {
			get;
			private set;
		} = new KeyMapCollection();

		/// <summary>
		/// キーマップデータを取得または設定します。
		/// </summary>
		[XmlIgnore]
		internal IKeyMapCollection KeyMap {
			get;
			private set;
		} = new KeyMapCollection();

		/// <summary>
		/// 継承元となるキーマップセット名を取得します。
		/// </summary>
		[XmlElement("extends")]
		public ExtendsCollection Extends {
			get;
		} = new ExtendsCollection();

		/// <summary>
		/// キーマップファイルのパスを取得または設定します。
		/// </summary>
		[XmlIgnore]
		private string ConfigPath {
			get;
			set;
		}

		#endregion

		#region ロード

		/// <summary>
		/// キーマップセットデータをファイルからロードします。
		/// </summary>
		/// <param name="configRoot">キーマップセットデータファイルが格納されているフォルダのパス。</param>
		/// <returns>キーマップセットデータのインスタンス。</returns>
		internal static KeyMapSet Load(string configRoot) {
			
			KeyMapSet keyMapSet;
			FileStream fs = null;
			var definFilePath = string.Empty;
			try {

				//定義ファイルのパスを生成
				definFilePath = Path.Combine(configRoot,"KeyMap.xml");

				//定義ファイルをデシリアライズ
				fs=new FileStream(definFilePath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				keyMapSet=new XmlSerializer(typeof(KeyMapSet)).Deserialize(fs) as KeyMapSet;

			} catch(Exception) {
				throw new LoadException();
			} finally {
				fs?.Dispose();
			}

			//キーマップデータのソース情報をキーマップデータに設定
			keyMapSet.KeyMap=keyMapSet.KeyMapSource;
			keyMapSet.KeyMapSource=null;

			//定義ファイルのパスを設定
			keyMapSet.ConfigPath=definFilePath;

			//チェック前に設定が必要な値をオートコンプリート
			keyMapSet.PreCheckAutoComplete(configRoot);

			return keyMapSet;
		}

		#endregion

		#region 継承

		/// <summary>
		/// 継承元のキーマップセットデータに設定されている値を継承する処理をします。
		/// </summary>
		/// <param name="keyMapDirPathList">キーマップが格納されているディレクトリのパスの配列。</param>
		/// <param name="keyMapFileList">キーマップファイル名が格納されたReadOnlyDictionary&lt;string,string&gt;のインスタンス。</param>
		internal void BaseKeyMapLoad(string[] keyMapDirPathList,ReadOnlyDictionary<string,string> keyMapFileList) {

			//パラメータチェック
			if(keyMapDirPathList==null) {
				throw new ArgumentNullException(nameof(keyMapDirPathList));
			} else if(keyMapFileList==null) {
				throw new ArgumentNullException(nameof(keyMapFileList));
			} else if(keyMapDirPathList.Length==0||keyMapFileList.Count==0) {
				return;
			}

			//キーマップセットデータ内のキーマップデータの継承処理
			this.KeyMapExtends(DefineLoader.KeyMap.ExtendsLevelEnum.InnerKeyMapSet);

			var status = false;

			foreach(var extendsKeyMapSetName in this.Extends) {

				//継承キーマップセット名が空の場合スキップ
				if(string.IsNullOrEmpty(extendsKeyMapSetName)) {
					continue;
				}

				foreach(var keyMapDirPath in keyMapDirPathList) {

					//キーマップセット格納フォルダパスを生成
					var keyMapPath = string.Empty;
					try {
						keyMapPath = Path.Combine(keyMapDirPath,extendsKeyMapSetName);
					} catch(Exception) {
						throw new LoadException();
					}

					//キーマップファイル名が有効ではない場合スキップ
					if(!keyMapFileList.ContainsKey(keyMapPath)) {
						continue;
					}

					//継承元キーマップをロード
					var baseKeyMapSet = Load(keyMapPath);

					//継承元キーマップセットデータの継承処理
					baseKeyMapSet.BaseKeyMapLoad(keyMapDirPathList,keyMapFileList);

					//ウィンドウの高さを継承
					if(this.WindowHeight==-1) {
						this.WindowHeight=baseKeyMapSet.WindowHeight;
					}

					//ウィンドウの幅を継承
					if(this.WindowWidth==-1) {
						this.WindowWidth=baseKeyMapSet.WindowWidth;
					}

					//キーマップセットの対象となる実行ファイルのパスを継承
					if(this.TargetExe.Count==0) {
						foreach(var targetExe in this.TargetExe) {
							this.TargetExe.Add(targetExe);
						}
					}

					//キーマップデータの継承処理
					var appendingKeyMapCollection = new KeyMapCollection();
					foreach(var baseKeyMap in baseKeyMapSet.KeyMap) {
						if(this.KeyMap.Find((KeyMap keyMap) => {
							return keyMap.Name==baseKeyMap.Name;
						})!=null) {
							continue;
						}
						var targetKeyMap = new KeyMap();
						appendingKeyMapCollection.Add(targetKeyMap);
						targetKeyMap.BaseKeyMapLoad(baseKeyMapSet.KeyMap,baseKeyMap,DefineLoader.KeyMap.ExtendsLevelEnum.InnerKeyMapSet);
					}
					foreach(var appendingKeyMap in appendingKeyMapCollection) {
						this.KeyMap.Add(appendingKeyMap);
					}
					status = true;
					break;
				}

			}

			if(!status&&this.Extends.Count>0) {
				throw new LoadException();
			}

			//キーマップセットデータを超えたキーマップデータの継承処理
			this.KeyMapExtends(DefineLoader.KeyMap.ExtendsLevelEnum.OuterKeyMapSet);

			this.KeyMap=new KeyMapReadOnlyCollection(this.KeyMap);
		}

		/// <summary>
		/// キーマップ情報の継承処理をします。
		/// </summary>
		private void KeyMapExtends(KeyMap.ExtendsLevelEnum processExtendsLevel) {
			foreach(var targetKeyMap in this.KeyMap) {
				targetKeyMap.BaseKeyMapLoad(this.KeyMap,processExtendsLevel);
			}
		}

		#endregion

		#region チェック

		/// <summary>
		/// 設定値のチェックを行います。
		/// </summary>
		internal void Check() {

			var ErrorMessage = new List<CheckException>();

			//ウィンドウの高さをチェック
			if(this.WindowHeight==0) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.WindowHeight.Zero) {
					Value=this.WindowHeight.ToString(CultureInfo.CurrentCulture)
				});
			} else if(this.WindowHeight<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.WindowHeight.Minus) {
					Value=this.WindowHeight.ToString(CultureInfo.CurrentCulture)
				});
			}

			//ウィンドウの幅をチェック
			if(this.WindowWidth==0) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.WindowWidth.Zero) {
					Value=this.WindowWidth.ToString(CultureInfo.CurrentCulture)
				});
			} else if(this.WindowWidth<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.WindowWidth.Minus) {
					Value=this.WindowWidth.ToString(CultureInfo.CurrentCulture)
				});
			}

			//デフォルトキーマップデータの存在、重複チェック
			var defaultCounter = 0;
			foreach(var keyMap in this.KeyMap) {
				if(keyMap.Default>0) {
					defaultCounter++;
				}
				foreach(var extendsValue in keyMap.Extends) {

					//キーマップデータの継承元となるキーマップデータの存在チェック
					if(!string.IsNullOrEmpty(extendsValue)&&this.KeyMap.Find((KeyMap searchTarget) => {
						return searchTarget.Name==extendsValue;
					})==null) {
						ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.KeyMapCheck.ExtendsError) {
							Value=extendsValue
						});
					}

				}
			}
			if(defaultCounter<1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.KeyMapCheck.DefaultMap.Zero) {
					Value=defaultCounter.ToString(CultureInfo.CurrentCulture)
				});
			} else if(defaultCounter>1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMapSet.KeyMapCheck.DefaultMap.Over) {
					Value=defaultCounter.ToString(CultureInfo.CurrentCulture)
				});
			}

			//キーマップデータのコレクションをチェック
			foreach(var keyMap in this.KeyMap) {
				ErrorMessage.AddRange(keyMap.Check(this.KeyMap));
			}


			if(ErrorMessage.Count>0) {

				//エラーへの追加情報の設定
				foreach(var ce in ErrorMessage) {
					ce.ConfigPath=this.ConfigPath;
				}

				//チェック例外をスロー
				throw new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.LoadMiss,new CheckExceptionCollection(ErrorMessage));
			}

		}

		#endregion

		#region オートコンプリート

		/// <summary>
		/// チェック前に設定が必要な値をオートコンプリート処理を行います。
		/// </summary>
		/// <param name="configRootPath">キーマップ設定のルートフォルダパス。</param>
		internal void PreCheckAutoComplete(string configRoot) {

			//引数チェック
			if(this.KeyMap==null) {
				return;
			}

			//キーマップデータのチェック前に設定が必要な値をオートコンプリート
			foreach(var keyMap in this.KeyMap) {
				keyMap.PreCheckAutoComplete(configRoot);
			}
		}

		/// <summary>
		/// 設定値が初期値となっている場合にオートコンプリートを行います。
		/// </summary>
		internal void AutoComplete() {

			//キーマップデータのコレクションを設定
			var mapSize = (this.KeyMap as KeyMapReadOnlyCollection).MapSize;
			foreach(var keyMap in this.KeyMap) {
				keyMap.AutoComplete(mapSize);
			}
			
			//ウィンドウの高さをオートコンプリート
			if(this.WindowHeight==-1) {
				foreach(var keyMap in this.KeyMap) {
					if(this.WindowHeight<keyMap.Height) {
						this.WindowHeight=keyMap.Height;
					}
				}
				this.WindowHeight=this.WindowHeight*110+10;
			}

			//ウィンドウの幅をオートコンプリート
			if(this.WindowWidth==-1) {
				foreach(var keyMap in this.KeyMap) {
					if(this.WindowWidth<keyMap.Width) {
						this.WindowWidth=keyMap.Width;
					}
				}
				this.WindowWidth=this.WindowWidth*110+10;
			}
			
		}

		#endregion

	}
}