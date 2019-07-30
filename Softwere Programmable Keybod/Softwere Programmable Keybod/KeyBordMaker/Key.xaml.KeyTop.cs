using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {
	public partial class Key {

		/// <summary>
		/// キートップとして表示するテキストを取得または設定します。
		/// </summary>
		private string KeyTop {
			get;
			set;
		}

		#region Active Image

		/// <summary>
		/// キーアクティブ化時にキートップとして表示する画像のパスを取得または設定します。
		/// </summary>
		private string KeyTopActiveImagePath {
			get;
			set;
		} = null;

		/// <summary>
		/// キーアクティブ化時にキートップとして表示する画像を取得または設定します。
		/// </summary>
		private Frame KeyTopActiveImage {
			get;
			set;
		} = null;

		#endregion

		#region Hover Image

		/// <summary>
		/// ポインターホバー時にキートップとして表示する画像のパスを取得または設定します。
		/// </summary>
		private string KeyTopHoverImagePath {
			get;
			set;
		} = null;

		/// <summary>
		/// ポインターホバー時にキートップとして表示する画像を取得または設定します。
		/// </summary>
		private Frame KeyTopHoverImage {
			get;
			set;
		} = null;

		#endregion

		#region Nomal Image

		/// <summary>
		/// キートップとして表示する画像のパスを取得または設定します。
		/// </summary>
		private string KeyTopImagePath {
			get;
			set;
		} = null;

		/// <summary>
		/// キートップとして表示する画像を取得または設定します。
		/// </summary>
		private Frame KeyTopImage {
			get;
			set;
		} = null;

		#endregion

		#region 表示制御用コントロール

		/// <summary>
		/// キートップに表示するビューボックスのインスタンスを取得します。
		/// </summary>
		private Viewbox KeyTopViewBox {
			get;
		} = new Viewbox() {
			Margin=new Thickness(0,0,0,0)
		};

		#endregion

		#region キートップ画像ロード処理

		/// <summary>
		/// キートップに表示する画像をロードします。
		/// </summary>
		/// <param name="token">スレッドキャンセル用トークン</param>
		internal void LoadKeyTopImage(CancellationToken token) {

			//キートップイメージのパスが設定されていない場合
			if(string.IsNullOrEmpty(this.KeyTopImagePath)) {

				//スレッドキャンセルチェック
				token.ThrowIfCancellationRequested();

				//キートップにテキストを設定
				Dispatcher.Invoke(() => {
					this.Content=this.KeyTop;
				});
				return;
			}

			try {

				//スレッドキャンセルチェック
				token.ThrowIfCancellationRequested();

				//キートップに表示するXAMLをロード
				var xaml = this.LoadXaml(this.KeyTopImagePath);

				//スレッドキャンセルチェック
				token.ThrowIfCancellationRequested();

				Dispatcher.Invoke(() => {

					//キートップに表示するXAMLを設定
					this.KeyTopImage=new Frame() {
						Content=xaml
					};

					//キートップを設定
					this.KeyTopViewBox.Child=this.KeyTopImage;
					this.Content=this.KeyTopViewBox;

				});

			} catch(XamlLoadException){

				//スレッドキャンセルチェック
				token.ThrowIfCancellationRequested();

				//画像のロードに失敗した場合、キートップにテキストを設定
				Dispatcher.Invoke(() => {
					this.Content=this.KeyTop;
				});

			}

		}

		/// <summary>
		/// キートップの追加画像をロードします。
		/// </summary>
		/// <param name="token">スレッドキャンセル用トークン</param>
		internal void LoadKeyTopAdvancedImage(CancellationToken token) {

			//スレッドキャンセルチェック
			token.ThrowIfCancellationRequested();

			//ポインターホバー時の画像を取得
			if(!string.IsNullOrEmpty(this.KeyTopHoverImagePath)) {
				try {

					//キートップに表示するXAMLをロード
					var xaml = this.LoadXaml(this.KeyTopHoverImagePath);

					//スレッドキャンセルチェック
					token.ThrowIfCancellationRequested();

					//キートップに表示するXAMLを設定
					Dispatcher.Invoke(() => {
						this.KeyTopHoverImage=new Frame() {
							Content=xaml
						};
					});

				} catch(XamlLoadException) {
					this.KeyTopHoverImage=null;
				}
			}

			//スレッドキャンセルチェック
			token.ThrowIfCancellationRequested();

			//キークティブ化時の画像を取得
			if(!string.IsNullOrEmpty(this.KeyTopActiveImagePath)) {
				try {

					//キートップに表示するXAMLをロード
					var xaml = this.LoadXaml(this.KeyTopActiveImagePath);

					//スレッドキャンセルチェック
					token.ThrowIfCancellationRequested();

					//キートップに表示するXAMLを設定
					Dispatcher.Invoke(() => {
						this.KeyTopActiveImage=new Frame() {
							Content=xaml
						};
					});

				} catch(XamlLoadException) {
					this.KeyTopActiveImage=null;
				}
			}

		}

		/// <summary>
		/// XAMLをロードします。
		/// </summary>
		/// <param name="path">ロードするXAMLのファイルパス。</param>
		/// <returns>ロードしたXAMLのUiElementインスタンス。</returns>
		private UIElement LoadXaml(string path) {
			UIElement xaml=null;
			FileStream stream=null;
			try {
				stream=new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				var xmlReader = XmlReader.Create(stream);
				Dispatcher.Invoke(() => {
					xaml=XamlReader.Load(xmlReader) as UIElement;
				});
			} catch(Exception ex) {
				throw new XamlLoadException(ex.Message,ex);
			} finally {
				stream?.Dispose();
			}
			return xaml;
		}

		#endregion

		#region キートップ画像の表示処理

		/// <summary>
		/// キートップをアクティブ時の画像に変更します。
		/// </summary>
		private void KeyTopChangeActive() {
			if(this.KeyTopActiveImage==null) {
				this.KeyTopChangeNormal();
			} else {
				this.SetKeyTop(this.KeyTopActiveImage);
			}
			this.Foreground=new SolidColorBrush(Color.FromArgb(0xFF,0xFF,0xFF,0xFF));
		}

		/// <summary>
		/// キートップをホバー次の画像に変更します。
		/// </summary>
		private void KeyTopChangeHover() {
			if(this.KeyTopHoverImage==null) {
				this.KeyTopChangeNormal();
			} else {
				this.SetKeyTop(this.KeyTopHoverImage);
			}
			this.Foreground=new SolidColorBrush(Color.FromArgb(0xFF,0x00,0x00,0x00));
		}

		/// <summary>
		/// キートップを通常画像に変更します。
		/// </summary>
		private void KeyTopChangeNormal() {
			if(this.KeyTopImage==null) {
				this.Content=KeyTop;
			} else {
				this.SetKeyTop(this.KeyTopImage);
			}
			this.Foreground=new SolidColorBrush(Color.FromArgb(0xFF,0xFF,0xFF,0xFF));
		}

		/// <summary>
		/// キートップを設定します。
		/// </summary>
		/// <param name="image">キートップに設定する画像のインスタンス。</param>
		private void SetKeyTop(Frame image) {
			if(this.KeyTopViewBox.Child!=image) {
				this.KeyTopViewBox.Child=image;
			}
			if(this.Content!=this.KeyTopViewBox){
				this.Content=this.KeyTopViewBox;
			}
		}

		#endregion

	}

}