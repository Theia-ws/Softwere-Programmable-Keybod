using System;
using System.Collections.Generic;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection {

	/// <summary>
	/// KeyMap コレクションのインタフェースです。
	/// </summary>
	interface IKeyMapCollection:IList<KeyMap> {

		/// <summary>
		/// 指定された述語によって定義された条件と一致する要素を検索し、IKeyMapCollection 全体の中で最もインデックス番号の小さい要素を返します。
		/// </summary>
		/// <param name="match">検索する要素の条件を定義する Predicate<Keymap> デリゲート。</param>
		/// <returns>見つかった場合は、指定された述語によって定義された条件と一致する最初の要素。それ以外の場合は、型 KeyMap の既定値。</returns>
		KeyMap Find(Predicate<KeyMap> match);

	}
}