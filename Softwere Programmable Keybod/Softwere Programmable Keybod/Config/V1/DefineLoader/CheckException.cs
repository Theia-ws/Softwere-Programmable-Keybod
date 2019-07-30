using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader.Collection;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader {

	/// <summary>
	/// チェックエラーが発生したときにスローされる例外。
	/// </summary>
	[Serializable]
	public class CheckException:Exception {

		#region コンストラクタ

		/// <summary>
		/// CheckException クラスの新しいインスタンスを初期化します。
		/// </summary>
		public CheckException() : base() {
		}

		/// <summary>
		/// 指定したエラー メッセージを使用して、CheckException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="message">エラーを説明するメッセージ。</param>
		public CheckException(string message) : base(message) {

		}

		/// <summary>
		/// 指定したエラー メッセージおよびこの例外の原因となった内部例外への参照を使用して、CheckException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <param name="innerException">現在の例外の原因である例外。内部例外が指定されていない場合は null 参照 (Visual Basic では、Nothing)。</param>
		public CheckException(string message,Exception innerException) : base(message,innerException) {
		}

		/// <summary>
		/// 指定したエラー メッセージおよびこの例外の原因となった内部例外リストへの参照を使用して、CheckException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="message">例外の原因を説明するエラー メッセージ。</param>
		/// <param name="innnerExceptionList">現在の例外の原因である例外リスト。内部例外が指定されていない場合は null 参照 (Visual Basic では、Nothing)。</param>
		internal CheckException(string message,CheckExceptionCollection innnerExceptionList) : base(message) {
			this.InnnerExceptionList=innnerExceptionList;
		}

		/// <summary>
		/// シリアル化したデータを使用して、CheckException クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="info">スローされている例外に関するシリアル化済みオブジェクト データを保持している SerializationInfo。</param>
		/// <param name="context">転送元または転送先についてのコンテキスト情報を含む StreamingContext です。</param>
		protected CheckException(SerializationInfo info,StreamingContext context) : base(info,context) {
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// 例外発生元のキーマップコンフィグファイルのパスを取得または設定します。
		/// </summary>
		internal string ConfigPath {
			get;
			set;
		} = null;

		/// <summary>
		/// 例外発生元のキーマップ名を取得または設定します。
		/// </summary>
		internal string KeyMapName {
			get;
			set;
		} = null;

		/// <summary>
		/// 例外発生元の行番号を取得または設定します。
		/// </summary>
		internal int RowNumber {
			get;
			set;
		} = -1;

		/// <summary>
		/// 例外発生元のキー番号を取得または設定します。
		/// </summary>
		internal int KeyNumber {
			get;
			set;
		} = -1;

		/// <summary>
		/// 例外発生元のインプットインデックスを取得または設定します。
		/// </summary>
		internal int InputIndex {
			get;
			set;
		} = -1;

		/// <summary>
		/// 例外発生原因となった値を取得または設定します。
		/// </summary>
		internal string Value {
			get;
			set;
		} = null;

		/// <summary>
		/// 例外の原因である例外リストを取得または設定します。
		/// </summary>
		internal CheckExceptionCollection InnnerExceptionList {
			get;
		}

		#endregion

		/// <summary>
		/// 派生クラスでオーバーライドされた場合は、その例外に関する情報を使用して SerializationInfo を設定します。
		/// </summary>
		/// <param name="info">スローされた例外に関する、シリアル化されたオブジェクト データを保持する SerializationInfo です。</param>
		/// <param name="context">転送元または転送先についてのコンテキスト情報を含む StreamingContext です。</param>
		[SecurityPermission(SecurityAction.Demand,SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info,StreamingContext context) {

			//引数チェック
			if(info==null) {
				throw new ArgumentNullException(nameof(info));
			}

			//シリアライズ
			base.GetObjectData(info,context);
			info.AddValue(nameof(ConfigPath),ConfigPath);
			info.AddValue(nameof(KeyMapName),KeyMapName);
			info.AddValue(nameof(RowNumber),RowNumber);
			info.AddValue(nameof(KeyNumber),KeyNumber);
			info.AddValue(nameof(InputIndex),InputIndex);
			info.AddValue(nameof(Value),Value);

		}

	}

}