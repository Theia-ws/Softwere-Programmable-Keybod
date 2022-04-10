using System;
using System.IO;
using System.Windows;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config {
	/// <summary>
	/// ConfigExample.xaml の相互作用ロジック
	/// </summary>
	public partial class ConfigExample:Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ConfigExample() => this.InitializeComponent();

		/// <summary>
		/// ウィンドウロード処理イベント
		/// </summary>
		/// <param name="sender">イベント ハンドラーが添付されるオブジェクト。</param>
		/// <param name="e">イベントのデータ。</param>
		private void Window_Loaded(object sender,RoutedEventArgs e) {

			try {

				this.LoadExample();
				
			} catch(ConfigExampleException) {
				_=MessageBox.Show(this,App.Language.ConfigExampleLoadMiss,App.Language.ConfigExampleLoadMiss,MessageBoxButton.OK,MessageBoxImage.Error);
				this.Close();
			}

		}

		/// <summary>
		/// キーマップ作成例ファイルをロードします。
		/// </summary>
		private void LoadExample() {
			//キーマップ作成例ファイルをロード
			FileStream fs = null;
			StreamReader sr = null;
			try {
				fs=new FileStream(Path.Combine(Environment.CurrentDirectory,"Config","KeyMap Example.xml"),FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				sr=new StreamReader(fs);
				fs=null;
				this.ExampleShow.Text=sr.ReadToEnd();
			} catch(Exception ex) {
				throw new ConfigExampleException(ex.Message,ex);
			} finally {
				sr?.Dispose();
				fs?.Dispose();
			}
		}

	}
}