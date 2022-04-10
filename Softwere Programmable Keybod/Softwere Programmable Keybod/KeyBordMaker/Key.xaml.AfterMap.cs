namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {
	public partial class Key {

		/// <summary>
		/// キー入力後に遷移するキーマップ名を取得または設定します。
		/// </summary>
		private string AfterMapName {
			get;
			set;
		}

		/// <summary>
		/// キー入力後に遷移するキーマップのインスタンスを取得または設定します。
		/// </summary>
		internal KeyMap AfterMap {
			get;
			private set;
		}

		/// <summary>
		/// キー入力後に遷移するキーマップのインスタンスを設定
		/// </summary>
		/// <param name="gridList">キーマップのリスト</param>
		internal void SetAfterMap(KeyMapList gridList) => this.AfterMap=string.IsNullOrEmpty(this.AfterMapName)||gridList==null ? null : gridList[this.AfterMapName];

		/// <summary>
		/// キーマップ遷移処理を取得または設定します。
		/// </summary>
		internal KeyMapChangeProcessMethod KeyMapChangeProcess {
			get;
			set;
		}

	}

	/// <summary>
	/// キー入力処理デリゲート
	/// </summary>
	/// <param name="afterMap">キー入力後に遷移するキーマップのインスタンス。</param>
	internal delegate void KeyMapChangeProcessMethod(KeyMap afterMap);

}