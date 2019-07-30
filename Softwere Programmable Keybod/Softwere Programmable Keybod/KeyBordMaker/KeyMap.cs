using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Collections.ObjectModel;
using System;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {

	/// <summary>
	/// キーボードに表示するキーマップのクラス
	/// </summary>
	class KeyMap:Grid {

		/// <summary>
		/// キートップに表示するキートップのインスタンスのリストを取得または設定します。
		/// </summary>
		internal ReadOnlyCollection<Key> Keys {
			get;
		}

		/// <summary>
		/// KeyMap クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="keyMap">キーマップ定義</param>
		internal KeyMap(Config.V1.DefineLoader.KeyMap keyMap) {

			if(keyMap==null) {
				throw new ArgumentNullException(nameof(keyMap));
			}

			//キーマップのプロパティを設定
			this.Margin=new Thickness(0,0,10,10);

			//Gridの行、列情報を登録
			for(var keyCounter = 0;keyCounter<keyMap.Width;keyCounter++) {
				this.ColumnDefinitions.Add(new ColumnDefinition() { Width=new GridLength(1,GridUnitType.Star) });
			}
			for(var rowCounter = 0;rowCounter<keyMap.Height;rowCounter++) {
				this.RowDefinitions.Add(new RowDefinition() { Height=new GridLength(1,GridUnitType.Star) });
			}

			//キーを作成
			this.Keys=Key.MakeKayArray(keyMap);

			//キートップのリストをキーマップに登録
			foreach(var Key in this.Keys) {
				this.Children.Add(Key);
			}

		}

		/// <summary>
		/// キートップに表示する画像をロードします。
		/// </summary>
		/// <param name="token">スレッドキャンセル用トークン</param>
		internal void LoadKeyTopImage(CancellationToken token) {
			foreach(var key in this.Keys) {
				key.LoadKeyTopImage(token);
			}
		}

		/// <summary>
		/// キートップの追加画像をロードします。
		/// </summary>
		/// <param name="token">スレッドキャンセル用トークン</param>
		internal void LoadKeyTopAdvancedImage(CancellationToken token) {
			foreach(var key in this.Keys) {
				key.LoadKeyTopAdvancedImage(token);
			}
		}

	}

}