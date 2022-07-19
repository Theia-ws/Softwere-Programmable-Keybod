using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection {

	/// <summary>
	/// 読み取り専用のキーマップデータ コレクションのクラスです。
	/// </summary>
	class KeyMapReadOnlyCollection:ReadOnlyCollection<KeyMap>, IKeyMapCollection {

		/// <summary>
		/// 指定したコレクションからコピーした要素を格納し、コピーされる要素の数を格納できるだけの容量を備えた、KeyMap クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="list">新しいリストにコピーされる要素のコレクション。 </param>
		internal KeyMapReadOnlyCollection(IList<KeyMap> list) : base(list) {

			//キーマップの縦横のキー数を算出
			var size = new Size();
			foreach(var keyMap in this) {
				var singleKeyMapSize = keyMap.MapSize;
				if(size.Width<singleKeyMapSize.Width) {
					size.Width=singleKeyMapSize.Width;
				}

				if(size.Height<singleKeyMapSize.Height) {
					size.Height=singleKeyMapSize.Height;
				}
			}

			this.MapSize=size;

		}

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を検索し、IKeyMapCollection 全体の中で最もインデックス番号の小さい要素を返します。
		/// </summary>
		/// <param name="match">検索する要素の条件を定義する Predicate<Keymap> デリゲート。</param>
		/// <returns>見つかった場合は、指定された述語によって定義された条件と一致する最初の要素。それ以外の場合は、型 KeyMap の既定値。</returns>
		public KeyMap Find(Predicate<KeyMap> match) {

			//引数チェック
			if(match==null) {
				throw new ArgumentNullException(nameof(match));
			}

			//検索処理
			foreach(var keyMap in this) {
				if(match(keyMap)) {
					return keyMap;
				}
			}

			return null;

		}

		/// <summary>
		/// キーマップの縦横のキー数を取得または設定します。
		/// </summary>
		internal Size MapSize {
			get;
		}
	}
}