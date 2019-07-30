using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection {

	/// <summary>
	/// 読み取り専用のチェック例外 コレクションのクラスです。
	/// </summary>
	class CheckExceptionCollection:ReadOnlyCollection<CheckException> {

		/// <summary>
		/// 指定したコレクションからコピーした要素を格納し、コピーされる要素の数を格納できるだけの容量を備えた、CheckExceptionCollection クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="list">新しいリストにコピーされる要素のコレクション。 </param>
		internal CheckExceptionCollection(IList<CheckException> list) : base(list) {
		}

	}

}