using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// 行データを格納するクラス。
	/// </summary>
	[Serializable]
	public class Row {

		#region プロパティ

		/// <summary>
		/// キーデータのコレクションを取得します。
		/// </summary>
		[XmlElement("key")]
		public KeyCollection Key {
			get;
		} = new KeyCollection();

		#endregion

		#region 継承

		/// <summary>
		/// 継承元の行データに設定されている値を継承する処理をします。
		/// </summary>
		/// <param name="baseRow">継承元の行データのインスタンス。</param>
		internal void BaseKeyMapLoad(Row baseRow) {

			//引数チェック
			if(baseRow==null) {
				throw new ArgumentNullException(nameof(baseRow));
			}

			//キーデータのコレクションの値を継承
			for(var keyCounter = 0;keyCounter<baseRow.Key.Count;keyCounter++) {
				if(keyCounter>=this.Key.Count) {
					var targetKey = new Key();
					this.Key.Add(targetKey);
					targetKey.BaseKeyMapLoad(baseRow.Key[keyCounter]);
				} else {
					this.Key[keyCounter].BaseKeyMapLoad(baseRow.Key[keyCounter]);
				}
			}

		}

		#endregion

		#region チェック

		/// <summary>
		/// 設定値のチェックを行います。
		/// </summary>
		/// <param name="keyMapList">キーデータの所属するキーマップリストのインスタンス。</param>
		/// <param name="rowNumber">行データが所属するキーマップデータのインスタンス内での行データの番号。</param>
		/// <returns>チェック結果の例外が格納されたリスト。</returns>
		internal CheckExceptionCollection Check(IList<KeyMap> keyMapList,int rowNumber) {

			var ErrorMessage = new List<CheckException>();

			//キーデータのコレクションをチェック
			for(var keyCounter = 0;keyCounter<this.Key.Count;keyCounter++) {
				ErrorMessage.AddRange(this.Key[keyCounter].Check(keyMapList,keyCounter));
			}

			//エラーへの追加情報の設定
			foreach(var item in ErrorMessage) {
				item.RowNumber=rowNumber;
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

			//キーデータのチェック前に設定が必要な値をオートコンプリート
			foreach(var key in this.Key) {
				key.PreCheckAutoComplete(configRootPath);
			}

		}

		/// <summary>
		/// 設定値が初期値となっている場合にオートコンプリートを行います。
		/// </summary>
		internal void AutoComplete() {

			//キーデータのコレクションを設定
			foreach(var key in this.Key) {
				key.AutoComplete();
			}

		}

		#endregion

	}

}