using System.Windows;
using System.Windows.Interop;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow:Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() => this.InitializeComponent();

		/// <summary>
		/// ウィンドウロード処理イベント
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void Window_Loaded(object sender,RoutedEventArgs args) {
			if(!NativeMethods.SetNotActiveWindow(((HwndSource)PresentationSource.FromVisual(this)).Handle)) {
				this.Close();
				return;
			}

			//タイトルバーのボタンに表示するアイコンを設定
			this.MinimizeButton.Content='\ue921';
			this.MaximizeAndRestoreButton.Content='\ue922';
			this.CloseButton.Content='\ue8bb';
			
			try {

				//通知領域アイコンを初期化
				App.NotifyIcon.MainWindow=this;

				//KeyMap定義マネージャを初期化
				App.DefineManager.KeybordWindow=this;
				App.DefineManager.KeybordGrid=this.MainGrid;

				//KeyMap定義をロード
				App.DefineManager.Load();

			} catch(LoadException) {
				this.Close();
			}

		}

		/// <summary>
		/// ウィンドウのサイズを設定します。
		/// </summary>
		/// <param name="width">ウィンドウの幅を示す値。</param>
		/// <param name="height">ウィンドウの高さを示す値。</param>
		internal void SetWindowSize(long width,long height) {
			this.Height=height+this.MainGrid.Margin.Top;
			this.Width=width;
		}

		/// <summary>
		/// 最小化ボタンクリック時のハンドラー。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MinimizeButton_Click(object sender,RoutedEventArgs e) => this.Hide();

		/// <summary>
		/// 最大化/最大化解除ボタンクリック時のハンドラー。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MaximizeAndRestoreButton_Click(object sender,RoutedEventArgs e) {
			if(this.WindowState!=WindowState.Maximized) {
				this.WindowState=WindowState.Maximized;
				this.MaximizeAndRestoreButton.Content='\ue923';
			} else {
				this.WindowState=WindowState.Normal;
				this.MaximizeAndRestoreButton.Content='\ue922';
			}
		}

		/// <summary>
		/// クローズボタンクリック時のハンドラー。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseButton_Click(object sender,RoutedEventArgs e) => this.Hide();

	}
}