using System;
using System.Runtime.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineImport {

	/// <summary>
	/// SVGからXAMLへのコンバートに失敗したときにスローされる例外。
	/// </summary>
	[Serializable]
	public class OldClearCancelException:ImportExceptionBase {

		/// <summary>
		/// OldClearCancelException クラスの新しいインスタンスを初期化します。
		/// </summary>
		public OldClearCancelException() : base() {
		}

		/// <summary>
		/// 指定したエラー メッセージを使用して、OldClearCancelException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="message">エラーを説明するメッセージ。</param>
		public OldClearCancelException(string message) : base(message) {
		}

		/// <summary>
		/// 指定したエラー メッセージおよびこの例外の原因となった内部例外への参照を使用して、OldClearCancelException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照 (Visual Basic では、Nothing)。</param>
		public OldClearCancelException(string message,Exception innerException) : base(message,innerException) {
		}

		/// <summary>
		/// シリアル化したデータを使用して、OldClearCancelException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="info">スローされている例外に関するシリアル化済みオブジェクト データを保持している SerializationInfo。</param>
		/// <param name="context">転送元または転送先についてのコンテキスト情報を含む StreamingContext です。</param>
		protected OldClearCancelException(SerializationInfo info,StreamingContext context) : base(info,context) {
		}
	}
}