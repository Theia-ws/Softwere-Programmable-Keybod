using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// キーデータを格納するクラス。
	/// </summary>
	[Serializable]
	public class Key {

		#region プロパティ

		/// <summary>
		/// キー入力後に遷移するキーマップ名を取得または設定します。
		/// </summary>
		[XmlAttribute("afterMap")]
		public string AfterMap {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// キーの高さを取得または設定します。
		/// </summary>
		[XmlAttribute("height")]
		public int Height {
			get;
			set;
		} = -1;

		/// <summary>
		/// キートップに表示する文字列を取得または設定します。
		/// </summary>
		[XmlAttribute("keyTop")]
		public string KeyTop {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// キーアクティブ化時にキートップに表示する画像のパスを取得または設定します。
		/// </summary>
		[XmlAttribute("keyTopActiveImage")]
		public string KeyTopActiveImage {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// ポインターホバー時にキートップに表示する画像のパスを取得または設定します。
		/// </summary>
		[XmlAttribute("keyTopHoverImage")]
		public string KeyTopHoverImage {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// キートップに表示する画像のパスを取得または設定します。
		/// </summary>
		[XmlAttribute("keyTopImage")]
		public string KeyTopImage {
			get;
			set;
		} = string.Empty;

		/// <summary>
		/// キーの幅を取得または設定します。
		/// </summary>
		[XmlAttribute("width")]
		public int Width {
			get;
			set;
		} = -1;

		/// <summary>
		/// インプットデータのコレクションを取得します。
		/// </summary>
		[XmlElement("inputData")]
		public InputDataCollection InputData {
			get;
		} = new InputDataCollection();

		#endregion

		#region 継承

		/// <summary>
		/// 継承元のキーデータに設定されている値を継承する処理をします。
		/// </summary>
		/// <param name="baseKey">継承元のキーデータのインスタンス。</param>
		internal void BaseKeyMapLoad(Key baseKey) {

			//引数チェック
			if(baseKey==null) {
				return;
			}

			//キー入力後に遷移するキーマップ名を継承
			if(string.IsNullOrEmpty(this.AfterMap)) {
				this.AfterMap=baseKey.AfterMap;
			}

			//キーの高さを継承
			if(this.Height==-1) {
				this.Height=baseKey.Height;
			}

			//キートップに表示する文字列を継承
			if(string.IsNullOrEmpty(this.KeyTop)) {
				this.KeyTop=baseKey.KeyTop;
			}

			//キーアクティブ化時にキートップに表示する画像のパスを継承
			if(string.IsNullOrEmpty(this.KeyTopActiveImage)) {
				this.KeyTopActiveImage=baseKey.KeyTopActiveImage;
			}

			//ポインターホバー時にキートップに表示する画像のパスを継承
			if(string.IsNullOrEmpty(this.KeyTopHoverImage)) {
				this.KeyTopHoverImage=baseKey.KeyTopHoverImage;
			}

			//キートップに表示する画像のパスを継承
			if(string.IsNullOrEmpty(this.KeyTopImage)) {
				this.KeyTopImage=baseKey.KeyTopImage;
			}

			//キーの幅を継承
			if(this.Width==-1) {
				this.Width=baseKey.Width;
			}

			//インプットデータのコレクションの値を継承
			if(this.InputData.Count==0) {
				foreach(var baseInputData in baseKey.InputData) {
					this.InputData.Add(new InputData() {
						AfterWaite=baseInputData.AfterWaite,
						Index=baseInputData.Index,
						Value=baseInputData.Value
					});
				}
			}

		}

		#endregion

		#region チェック

		/// <summary>
		/// 設定値のチェックを行います。
		/// </summary>
		/// <param name="keyMapList">キーデータの所属するキーマップリストのインスタンス。</param>
		/// <param name="keyNumber">キーデータが所属する行データのインスタンス内でのキーデータの番号。</param>
		/// <returns>チェック結果の例外が格納されたリスト。</returns>
		internal CheckExceptionCollection Check(IList<KeyMap> keyMapList,int keyNumber) {

			//引数チェック
			if(keyMapList==null) {
				throw new ArgumentNullException(nameof(keyMapList));
			}

			var ErrorMessage = new List<CheckException>();

			//キー入力後に遷移するキーマップ名をチェック
			if(!string.IsNullOrEmpty(this.AfterMap)) {
				var status = false;
				foreach(var keyMap in keyMapList) {
					if(this.AfterMap==keyMap.Name) {
						status=true;
						break;
					}
				}
				if(!status) {
					ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.Key.NoAflterMap) {
						Value=this.AfterMap
					});
				}
			}

			//キーの高さをチェック
			if(this.Height<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.Key.Height.Minus) {
					Value=this.Height.ToString(CultureInfo.CurrentCulture)
				});
			} else if(this.Height==0) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.Key.Height.Zero) {
					Value=this.Height.ToString(CultureInfo.CurrentCulture)
				});
			}

			//キーの幅をチェック
			if(this.Width<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.Key.Width.Minus) {
					Value=this.Width.ToString(CultureInfo.CurrentCulture)
				});
			} else if(this.Width==0) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.Key.Width.Zero) {
					Value=this.Width.ToString(CultureInfo.CurrentCulture)
				});
			}

			//インプットデータのコレクションをチェック
			for(var inputDataCounter = 0;inputDataCounter<this.InputData.Count;inputDataCounter++) {
				ErrorMessage.AddRange(this.InputData[inputDataCounter].Check(this,inputDataCounter));
			}

			//エラーへの追加情報の設定
			foreach(var item in ErrorMessage) {
				item.KeyNumber=keyNumber;
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

			try {

				//アクティブ時にキートップに表示する画像のパスを絶対パスに変換
				if(!string.IsNullOrEmpty(this.KeyTopActiveImage)&&!Path.IsPathRooted(this.KeyTopActiveImage)) {
					this.KeyTopActiveImage=Path.Combine(configRootPath,this.KeyTopActiveImage);
				}

				//ホバー時にキートップに表示する画像のパスを絶対パスに変換
				if(!string.IsNullOrEmpty(this.KeyTopHoverImage)&&!Path.IsPathRooted(this.KeyTopHoverImage)) {
					this.KeyTopHoverImage=Path.Combine(configRootPath,this.KeyTopHoverImage);
				}

				//通常時にキートップに表示する画像のパスを絶対パスに変換
				if(!string.IsNullOrEmpty(this.KeyTopImage)&&!Path.IsPathRooted(this.KeyTopImage)) {
					this.KeyTopImage=Path.Combine(configRootPath,this.KeyTopImage);
				}

			} catch(Exception) {
				throw new LoadException();
			}

		}

		/// <summary>
		/// 設定値が初期値となっている場合にオートコンプリートを行います。
		/// </summary>
		internal void AutoComplete() {

			//キーの高さを設定
			if(this.Height==-1) {
				this.Height=1;
			}

			//キーの幅を設定
			if(this.Width==-1) {
				this.Width=1;
			}

			//インプットデータのコレクションを設定
			foreach(var inputData in this.InputData) {
				inputData.AutoComplete();
			}

		}

		#endregion

	}

}