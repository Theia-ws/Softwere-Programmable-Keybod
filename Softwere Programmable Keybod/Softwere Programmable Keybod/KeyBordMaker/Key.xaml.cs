using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {
	/// <summary>
	/// Key.xaml の相互作用ロジック
	/// </summary>
	public partial class Key:Button {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Key() => this.InitializeComponent();

		/// <summary>
		/// キーマップ定義を元にキー配列を生成します。
		/// </summary>
		/// <param name="keyMapDefine">キーマップ定義。</param>
		/// <param name="windowWidth">ウィンドウの幅。</param>
		/// <param name="windowHeight">ウィンドウの高さ。</param>
		/// <returns></returns>
		internal static ReadOnlyCollection<Key> MakeKayArray(Config.V1.DefineLoader.KeyMap keyMapDefine) {

			var keyMap = new List<Key>();

			//引数チェック
			if(keyMapDefine==null) {
				return new ReadOnlyCollection<Key>(keyMap);
			}

			//キーマップ定義の行を処理
			for(var rowCounter = 0;rowCounter<keyMapDefine.Row.Count;rowCounter++) {

				//キーマップ定義の列を処理
				for(var keyCounter = 0;keyCounter<keyMapDefine.Row[rowCounter].Key.Count;keyCounter++) {

					//キーに入力値がない場合スキップ
					if(keyMapDefine.Row[rowCounter].Key[keyCounter].InputData.Count<=0) {
						continue;
					}

					//キーとなるボタンのインスタンスを生成
					var key = new Key() {
						AfterMapName=keyMapDefine.Row[rowCounter].Key[keyCounter].AfterMap,
						KeyInput=MakeKeyInput(keyMapDefine.Row[rowCounter].Key[keyCounter]),
						KeyTop=keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTop,
						KeyTopActiveImagePath=string.IsNullOrEmpty(keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopActiveImage) ? null : keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopActiveImage+".xaml",
						KeyTopHoverImagePath=string.IsNullOrEmpty(keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopHoverImage) ? null : keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopHoverImage+".xaml",
						KeyTopImagePath=string.IsNullOrEmpty(keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopImage) ? null : keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTopImage+".xaml",
						Margin=new Thickness(10,10,0,0),
						ToolTip=keyMapDefine.Row[rowCounter].Key[keyCounter].KeyTop
					};
					key.SetValue(Grid.RowProperty,rowCounter);
					key.SetValue(Grid.ColumnProperty,keyCounter);
					key.SetValue(Grid.ColumnSpanProperty,keyMapDefine.Row[rowCounter].Key[keyCounter].Width);
					key.SetValue(Grid.RowSpanProperty,keyMapDefine.Row[rowCounter].Key[keyCounter].Height);
					

					//キー入力イベントを設定
					key.Click+=new RoutedEventHandler(key.KeyClickEvent);

					//キー配列に登録
					keyMap.Add(key);

				}

			}

			return new ReadOnlyCollection<Key>(keyMap);
		}

	}

}