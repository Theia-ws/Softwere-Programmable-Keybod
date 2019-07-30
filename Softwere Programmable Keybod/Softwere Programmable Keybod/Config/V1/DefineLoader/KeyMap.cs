using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml.Serialization;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// キーマップデータを格納するクラス。
	/// </summary>
	[Serializable]
	public class KeyMap {

		#region プロパティ

		/// <summary>
		/// 初期マップフラグを取得または設定します。
		/// </summary>
		[XmlAttribute("default")]
		public int Default {
			get;
			set;
		} = -1;

		/// <summary>
		/// 継承元となるキーマップ名を取得します。
		/// </summary>
		[XmlElement("extends")]
		public ExtendsCollection Extends {
			get;
		} = new ExtendsCollection();

		/// <summary>
		/// キーマップの高さ方向のキー個数を取得または設定します。
		/// </summary>
		[XmlAttribute("height")]
		public int Height {
			get;
			set;
		} = -1;

		/// <summary>
		/// キーマップ名を取得または設定します。
		/// </summary>
		[XmlAttribute("name")]
		public string Name {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// キーマップの幅方向のキー個数を取得または設定します。
		/// </summary>
		[XmlAttribute("width")]
		public int Width {
			get;
			set;
		} = -1;

		/// <summary>
		/// 行データのコレクションを取得します。
		/// </summary>
		[XmlElement("row")]
		public RowCollection Row {
			get;
		} = new RowCollection();

		/// <summary>
		/// キーマップのマップサイズを取得します。
		/// </summary>
		[XmlIgnore]
		internal Size MapSize => new Size() {
			Height=this.Height==-1 ? this.Row.Count : this.Height,
			Width=GetWidth()
		};

		/// <summary>
		/// キーマップの幅を取得します。
		/// </summary>
		/// <returns>キーマップの幅。</returns>
		private int GetWidth() {
			if(this.Width!=-1) {
				return this.Width;
			}
			var width = 0;
			foreach(var row in this.Row) {
				if(width<row.Key.Count) {
					width=row.Key.Count;
				}
			}
			return width;
		}

		#endregion

		#region 継承

		/// <summary>
		/// 継承レベル
		/// </summary>
		internal enum ExtendsLevelEnum {
			None = 0,
			InnerKeyMapSet = 1,
			OuterKeyMapSet = 3
		}

		/// <summary>
		/// 継承レベルを取得または設定します。
		/// </summary>
		private ExtendsLevelEnum ExtendsLevel {
			get;
			set;
		} = ExtendsLevelEnum.None;

		/// <summary>
		/// 継承元のキーマップデータに設定されている値を継承する処理をします。
		/// </summary>
		/// <param name="baseKeyMapColection">継承元のキーマップデータコレクションのインスタンス。</param>
		/// <param name="processExtendsLevel">処理対象となる継承レベル</param>
		internal void BaseKeyMapLoad(IKeyMapCollection baseKeyMapColection,ExtendsLevelEnum processExtendsLevel) {

			//引数チェック
			if(baseKeyMapColection==null) {
				throw new ArgumentNullException(nameof(baseKeyMapColection));
			} else if(processExtendsLevel<=this.ExtendsLevel) {
				return;
			}

			foreach(var extendsKeyMapName in this.Extends){

				//継承キーマップ名が空の場合スキップ
				if(string.IsNullOrEmpty(extendsKeyMapName)) {
					continue;
				}

				//継承元キーマップデータを取得
				var baseKeyMap = baseKeyMapColection.Find((KeyMap keyMap) => {
					return keyMap.Name==extendsKeyMapName;
				});

				//継承元キーマップデータが取得できない場合スキップ
				if(baseKeyMap==null) {
					continue;
				}

				//データのコピー処理
				this.BaseKeyMapLoadCopyData(baseKeyMapColection,baseKeyMap,processExtendsLevel);

			}

		}

		/// <summary>
		/// 継承元のキーマップデータに設定されている値を継承する処理をします。
		/// </summary>
		/// <param name="baseKeyMapColection">継承元のキーマップデータコレクションのインスタンス。</param>
		/// <param name="baseKeyMap">継承元のキーマップデータのインスタンス。</param>
		/// <param name="processExtendsLevel">処理対象となる継承レベル</param>
		internal void BaseKeyMapLoad(IKeyMapCollection baseKeyMapColection,KeyMap baseKeyMap,ExtendsLevelEnum processExtendsLevel) {

			//引数チェック
			if(baseKeyMapColection==null) {
				throw new ArgumentNullException(nameof(baseKeyMapColection));
			} else if(baseKeyMap==null) {
				throw new ArgumentNullException(nameof(baseKeyMap));
			} else if(processExtendsLevel<=this.ExtendsLevel) {
				return;
			}

			//データのコピー処理
			this.BaseKeyMapLoadCopyData(baseKeyMapColection,baseKeyMap,processExtendsLevel);

		}

		/// <summary>
		/// 継承元のキーマップデータに設定されている値を継承するデータコピー処理をします。
		/// </summary>
		/// <param name="baseKeyMapColection">継承元のキーマップデータコレクションのインスタンス。</param>
		/// <param name="baseKeyMap">継承元のキーマップデータのインスタンス。</param>
		/// <param name="processExtendsLevel">処理対象となる継承レベル</param>
		private void BaseKeyMapLoadCopyData(IKeyMapCollection baseKeyMapColection,KeyMap baseKeyMap,ExtendsLevelEnum processExtendsLevel) {

			//継承元キーマップデータの継承処理
			baseKeyMap.BaseKeyMapLoad(baseKeyMapColection,processExtendsLevel);

			//初期マップフラグを継承
			if(this.Default==-1) {
				this.Default=baseKeyMap.Default;
			}

			//キーマップの高さ方向のキー個数を継承
			if(this.Height==-1) {
				this.Height=baseKeyMap.Height;
			}
			/// キーマップ名を継承
			if(string.IsNullOrEmpty(this.Name)) {
				this.Name=baseKeyMap.Name;
			}

			// キーマップの幅方向のキー個数を継承
			if(this.Width==-1) {
				this.Width=baseKeyMap.Width;
			}

			//行データのコレクションの値を継承
			for(var rowCounter = 0;rowCounter<baseKeyMap.Row.Count;rowCounter++) {
				if(rowCounter>=this.Row.Count) {
					var targetRow = new Row();
					this.Row.Add(targetRow);
					targetRow.BaseKeyMapLoad(baseKeyMap.Row[rowCounter]);
				} else {
					this.Row[rowCounter].BaseKeyMapLoad(baseKeyMap.Row[rowCounter]);
				}
			}
			this.ExtendsLevel=processExtendsLevel;
		}

		#endregion

		#region チェック

		/// <summary>
		/// 設定値のチェックを行います。
		/// </summary>
		/// <param name="keyMapList">キーマップデータの所属するキーマップリストのインスタンス。</param>
		/// <returns>チェック結果の例外が格納されたリスト。</returns>
		internal CheckExceptionCollection Check(IList<KeyMap> keyMapList) {

			var ErrorMessage = new List<CheckException>();

			//キーマップの高さ方向のキー個数をチェック
			if(this.Height<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMap.Height) {
					Value=this.Height.ToString(CultureInfo.CurrentCulture)
				});
			}

			//継承元のチェック
			foreach(var extends in this.Extends) {
				var status = false;
				if(keyMapList!=null) {
					foreach(var keyMap in keyMapList) {
						if(extends==keyMap.Name) {
							status=true;
							break;
						}
					}
				}
				if(!status) {
					ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMap.NoExtendsMap) {
						Value=extends
					});
				}
			}

			//キーマップ名をチェック
			if(string.IsNullOrEmpty(this.Name)) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMap.NoName) {
					Value=this.Name
				});
			}

			//キーマップの幅方向のキー個数をチェック
			if(this.Width<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.KeyMap.Width) {
					Value=this.Width.ToString(CultureInfo.CurrentCulture)
				});
			}

			//行データのコレクションをチェック
			for(var rowCounter = 0;rowCounter<this.Row.Count;rowCounter++) {
				ErrorMessage.AddRange(this.Row[rowCounter].Check(keyMapList,rowCounter));
			}

			//エラーへの追加情報の設定
			foreach(var item in ErrorMessage) {
				item.KeyMapName=this.Name;
			}

			return new CheckExceptionCollection(ErrorMessage);
		}

		#endregion

		#region オートコンプリート

		/// <summary>
		/// チェック前に設定が必要な値をオートコンプリートする。
		/// </summary>
		/// <param name="configRootPath">キーマップ設定のルートフォルダパス。</param>
		internal void PreCheckAutoComplete(string configRootPath) {

			//行データのチェック前に設定が必要な値をオートコンプリート
			foreach(var row in this.Row) {
				row.PreCheckAutoComplete(configRootPath);
			}

		}

		/// <summary>
		/// 設定値が初期値となっている場合にオートコンプリートを行います。
		/// </summary>
		/// <param name="size">オートコンプリートするキーマップのサイズ。</param>
		internal void AutoComplete(Size size) {

			//初期マップフラグを設定
			if(this.Default==-1) {
				this.Default=0;
			}

			//キーマップの高さ方向のキー個数を設定
			if(this.Height==-1) {
				this.Height=size.Height;
			}

			//キーマップの幅方向のキー個数を設定
			if(this.Width==-1) {
				this.Width=size.Width;
			}

			//行データのコレクションを設定
			foreach(var row in this.Row) {
				row.AutoComplete();
			}

		}

		#endregion

	}
}