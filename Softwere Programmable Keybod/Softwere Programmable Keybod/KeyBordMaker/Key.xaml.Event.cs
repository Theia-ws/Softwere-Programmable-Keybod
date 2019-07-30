using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader;
using WS.Theia.Library.SendKeys;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {
	public partial class Key {

		/// <summary>
		/// キーステータスが変更されたときに発生します。
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusChanged;

		/// <summary>
		/// キーにポインターが重なった時に発生します。
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusHover;

		/// <summary>
		/// キーからポインターが外れた時に発生します。
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusLeave;

		/// <summary>
		/// キーが押下状態になった時に発生します。
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusDown;

		/// <summary>
		/// キーが押下状態でなくなったときに発生します。
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusUp;

		/// <summary>
		/// キーにポインターが重なると同時に、押下状態になった時に発生します。(通常は発生しません)
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusHoverAndDown;

		/// <summary>
		/// キーが押下状態でなくなると同時に、キーからポインターが外れた時に発生します。（通常発生しません）
		/// </summary>
		internal event DependencyPropertyChangedEventHandler KeyStatusUpAndLeave;

		/// <summary>
		/// キーステータス変更イベント発生時のイベント分類を行います。
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void Border_DataContextChanged(object sender,DependencyPropertyChangedEventArgs e) {
			var oldValue = e.OldValue.ToString();
			if("0"==oldValue) {

				//通常状態から変更された場合
				this.StatusChangedFromNormal(sender,e);

			} else if("1"==oldValue) {

				//ホバー状態から変更された場合
				this.StatusChangedFromHover(sender,e);

			} else if("2"==oldValue) {

				//アクティブ状態から変更された場合
				this.StatusChangedFromActive(sender,e);

			} else {
				throw new ArgumentOutOfRangeException(nameof(e));
			}
		}

		/// <summary>
		/// アクティブ状態からのキーステータス変更イベント発生時のイベント分類を行います。
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void StatusChangedFromActive(object sender,DependencyPropertyChangedEventArgs e) {
			var newValue = e.NewValue.ToString();
			if("0"==newValue) {

				//通常状態に変更された場合
				this.KeyStatusUpAndLeave?.Invoke(sender,e);
				this.KeyStatusUp?.Invoke(sender,e);
				this.KeyStatusLeave?.Invoke(sender,e);
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyTopChangeNormal();

			} else if("1"==newValue) {

				//ホバー状態に変更された場合
				this.KeyStatusUp?.Invoke(sender,e);
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyTopChangeHover();

			} else {
				throw new ArgumentOutOfRangeException(nameof(e));
			}
		}

		/// <summary>
		/// ホバー状態からのキーステータス変更イベント発生時のイベント分類を行います。
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void StatusChangedFromHover(object sender,DependencyPropertyChangedEventArgs e) {
			var newValue = e.NewValue.ToString();
			if("0"==newValue) {

				//通常状態に変更された場合
				this.KeyStatusLeave?.Invoke(sender,e);
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyTopChangeNormal();

			} else if("2"==newValue) {

				//アクティブ状態に変更された場合
				this.KeyTopChangeActive();
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyStatusDown?.Invoke(sender,e);

			} else {
				throw new ArgumentOutOfRangeException(nameof(e));
			}
		}

		/// <summary>
		/// 通常状態からのキーステータス変更イベント発生時のイベント分類を行います。
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void StatusChangedFromNormal(object sender,DependencyPropertyChangedEventArgs e) {
			var newValue = e.NewValue.ToString();
			if("1"==newValue) {

				//ホバー状態に変更された場合
				this.KeyTopChangeHover();
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyStatusHover?.Invoke(sender,e);

			} else if("2"==newValue) {

				//アクティブ状態に変更された場合
				this.KeyTopChangeActive();
				this.KeyStatusChanged?.Invoke(sender,e);
				this.KeyStatusHover?.Invoke(sender,e);
				this.KeyStatusDown?.Invoke(sender,e);
				this.KeyStatusHoverAndDown?.Invoke(sender,e);

			} else {
				throw new ArgumentOutOfRangeException(nameof(e));
			}
		}

		/// <summary>
		/// キー入力を取得または設定します。
		/// </summary>
		private InputData[] KeyInput {
			get;
			set;
		}

		/// <summary>
		/// キー入力の値を生成
		/// </summary>
		/// <param name="key">キー定義</param>
		/// <returns>キー入力を示す値</returns>
		private static InputData[] MakeKeyInput(Config.V1.DefineLoader.Key key) {

			var keyInputList = new List<InputData>();
			
			//キー入力を登録
			foreach(var inputData in key.InputData) {
				keyInputList.Add(inputData);
			}
			//キー入力をインデックス順にソート
			keyInputList.Sort((beforeEle,afterEle) => beforeEle.Index-afterEle.Index);

			return keyInputList.ToArray();
		}

		/// <summary>
		/// キークリック処理イベント
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void KeyClickEvent(object sender,RoutedEventArgs e) {
			
			//フォアグラウンドのウィンドウを取得
			NativeMethods.SetForegroundWindow(NativeMethods.GetForegroundWindow());

			foreach(var inputData in this.KeyInput) {

				//キー入力を送信
				//TODO:System.Windows.Forms.SendKeys.SendWait(inputData.Value);
				inputData.Value.SendKeys();

				//ウェイトタイムの間待機
				Thread.Sleep(inputData.AfterWaite);

			}

			//キー入力後に遷移するキーマップが設定されている場合、キーマップ遷移処理を実行
			if(this.AfterMap!=null) {
				KeyMapChangeProcess?.Invoke(this.AfterMap);
			}

		}

	}

}
