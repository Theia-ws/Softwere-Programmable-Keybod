using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// インプットデータを格納するクラス。
	/// </summary>
	[Serializable]
	public class InputData {

		#region プロパティ

		/// <summary>
		/// アフターウェイト値を取得または設定します。
		/// </summary>
		[XmlAttribute("afterWaite")]
		public int AfterWaite {
			get;
			set;
		} = -1;

		/// <summary>
		/// 入力インデックス値を取得または設定します。
		/// </summary>
		[XmlAttribute("index")]
		public int Index {
			get;
			set;
		} = -1;

		/// <summary>
		/// 入力値を取得または設定します。
		/// </summary>
		[XmlText]
		public string Value {
			get;
			set;
		}

		#endregion

		#region チェック処理

		/// <summary>
		/// 設定値のチェックを行います。
		/// </summary>
		/// <param name="piarent">インプットデータが所属するキーのインスタンス。</param>
		/// <param name="thisInputKey">インプットデータが所属するキーデータのインスタンス内でのインプットデータの番号。</param>
		/// <returns>チェック結果の例外が格納されたリスト。</returns>
		internal CheckExceptionCollection Check(Key piarent,int thisInputKey) {

			//引数チェック
			if(piarent==null) {
				throw new ArgumentNullException(nameof(piarent));
			}

			var ErrorMessage = new List<CheckException>();

			//アフターウェイト値をチェック
			if(this.AfterWaite<0) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.InputData.AfterWateMinus) {
					Value=this.AfterWaite.ToString(CultureInfo.CurrentCulture)
				});
			}

			//入力インデックス値をチェック
			if(this.Index<-1) {
				ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.InputData.Index.Minus) {
					Value=this.Index.ToString(CultureInfo.CurrentCulture)
				});
			} else if(thisInputKey!=int.MaxValue) {
				for(var inputDataCounter = thisInputKey+1;inputDataCounter<piarent.InputData?.Count;inputDataCounter++) {
					if(this.Index==piarent.InputData[inputDataCounter].Index) {
						ErrorMessage.Add(new CheckException(App.Language.KeyMapSetLoder.ErrorMessages.InputData.Index.Duplicate) {
							Value=this.Index.ToString(CultureInfo.CurrentCulture)
						});
					}
				}
			}

			//エラーへの追加情報の設定
			foreach(var item in ErrorMessage) {
				item.InputIndex=this.Index;
			}

			return new CheckExceptionCollection(ErrorMessage);

		}

		#endregion

		#region オートコンプリート

		/// <summary>
		/// 設定値が初期値となっている場合にオートコンプリートを行います。
		/// </summary>
		internal void AutoComplete() {

			//アフターウェイト値を設定
			if(this.AfterWaite==-1) {
				this.AfterWaite=0;
			}

			//入力インデックス値を設定
			if(this.Index==-1) {
				this.Index=0;
			}

		}

		#endregion

	}

}