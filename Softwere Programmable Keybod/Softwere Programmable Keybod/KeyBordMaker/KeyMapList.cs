using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineLoader;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.KeyBordMaker {

	/// <summary>
	/// キーボードに表示するキートップの一覧を保持するクラス
	/// </summary>
	[Serializable]
	class KeyMapList:ReadOnlyDictionary<string,KeyMap> {

		#region プロパティ

		/// <summary>
		/// キーマップの高さを取得または設定します。
		/// </summary>
		internal int Height {
			get;
			private set;
		}

		/// <summary>
		/// キーマップの幅を取得または設定します。
		/// </summary>
		internal int Width {
			get;
			private set;
		}

		/// <summary>
		/// キーマップの登録先となるGrid クラスのインスタンスを取得または設定します。
		/// </summary>
		private Grid PiarentGrid {
			get;
			set;
		}

		/// <summary>
		/// デフォルトのキーマップを取得または設定します。
		/// </summary>
		private KeyMap DefaultKeyMap {
			get;
			set;
		}

		/// <summary>
		/// 現在表示中のキーマップを取得または設定します。
		/// </summary>
		private KeyMap NowMap {
			get;
			set;
		}

		/// <summary>
		/// キートップの更新処理スレッドのキャンセルトークンを取得または設定します。
		/// </summary>
		private CancellationTokenSource KeyTopUpdateTokenSource {
			get;
			set;
		}

		/// <summary>
		/// キートップ更新処理スレッドのインスタンスを取得または設定します。
		/// </summary>
		private Task KeyTopUpdateTask {
			get;
			set;
		}

		#endregion

		#region キーマップリスト生成

		/// <summary>
		/// キーマップリストを作成します。
		/// </summary>
		/// <param name="keyMapSet">キーマップセット定義のインスタンス。</param>
		/// <param name="piarent">キーマップの登録先となるGrid クラスのインスタンス。</param>
		/// <returns>キーマップリストのインスタンス</returns>
		internal static KeyMapList MakeKeyMapList(KeyMapSet keyMapSet,Grid piarent) {

			//引数チェック
			if(keyMapSet==null) {
				return null;
			}

			//キーマップを生成
			var keyMapDictionary = new Dictionary<string,KeyMap>();
			KeyMap defaultKeyMap = null;
			for(var keyMapCounter = 0;keyMapCounter<keyMapSet.KeyMap.Count;keyMapCounter++) {
				var keyMap = new KeyMap(keyMapSet.KeyMap[keyMapCounter]);
				keyMapDictionary.Add(keyMapSet.KeyMap[keyMapCounter].Name,keyMap);
				if(keyMapSet.KeyMap[keyMapCounter].Default>0) {
					defaultKeyMap=keyMap;
				}
			}

			//キーマップリストに値を設定
			var keyMapList = new KeyMapList(keyMapDictionary) {
				DefaultKeyMap=defaultKeyMap,
				Height=keyMapSet.WindowHeight,
				PiarentGrid=piarent,
				Width=keyMapSet.WindowWidth
			};

			//キーマップ変更処理をキーに設定
			foreach(var keyMap in keyMapList) {
				foreach(var key in keyMap.Value.Keys) {
					key.SetAfterMap(keyMapList);
					key.KeyMapChangeProcess+=keyMapList.KeyMapChenge;
				}
			}

			return keyMapList;
		}

		/// <summary>
		/// KeyMapList クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="source">KeyMapList に登録するKiyMap クラスのインスタンスのソース。</param>
		private KeyMapList(IDictionary<string,KeyMap> source) : base(source) {
		}

		#endregion

		#region キーマップの遷移処理

		/// <summary>
		/// デフォルトのキーマップに遷移します。
		/// </summary>
		internal void TransitionDefaultKeyMap() {
			this.KeyMapChenge(this.DefaultKeyMap);
		}

		/// <summary>
		/// キーマップを登録先となるGrid クラスから削除を行います。
		/// </summary>
		internal void RemoveKeyMap() {

			//キーマップが登録されていない場合スキップ
			if(this.NowMap==null) {
				return;
			}

			//キーマップを登録先となるGrid クラスから削除
			this.PiarentGrid.Children.Remove(NowMap);
			this.NowMap=null;

		}

		/// <summary>
		/// キーマップの変更処理を行います。
		/// </summary>
		/// <param name="newMap">遷移先のキーマップ。</param>
		private void KeyMapChenge(KeyMap newMap) {

			//キーマップが登録されている場合を登録先となるGrid クラスから削除
			if(this.NowMap!=null) {
				this.PiarentGrid.Children.Remove(NowMap);
			}

			//遷移先となるキーマップをGrid クラスに登録
			this.PiarentGrid.Children.Add(newMap);
			this.NowMap=newMap;

		}

		#endregion

		#region キートップ表示画僧ロード処理

		/// <summary>
		/// キートップに表示する画像をロードします。
		/// </summary>
		internal void LoadKeyTopImage() {
			this.KeyTopUpdateTask=new Task(new Action(this.LoadKeyTopImageTaskMethod));
			this.KeyTopUpdateTask.Start();
		}

		/// <summary>
		/// キートップの表示する画像をロードするスレッド内で実行するメソッド。
		/// </summary>
		internal void LoadKeyTopImageTaskMethod() {

			//スレッドキャンセルトークンを生成
			this.KeyTopUpdateTokenSource=new CancellationTokenSource();
			try {

				//キートップに表示する画像のロード処理
				foreach(var keyMap in this) {
					keyMap.Value.LoadKeyTopImage(this.KeyTopUpdateTokenSource.Token);
				}

				//キートップの追加画像のロード処理
				foreach(var keyMap in this) {
					keyMap.Value.LoadKeyTopAdvancedImage(this.KeyTopUpdateTokenSource.Token);
				}

			} catch(OperationCanceledException) { 
			} finally {

				//スレッドキャンセルトークンをクリア
				this.KeyTopUpdateTokenSource=null;

			}
		}

		/// <summary>
		/// キートップの表示をキャンセルします。
		/// </summary>
		internal void KeyTopUpdataCancel() {

			//キートップ表示更新スレッドのトークンをキャンセルに設定
			this.KeyTopUpdateTokenSource?.Cancel();
			

			//キートップ表示更新スレッドの終了を待機
			this.KeyTopUpdateTask?.Wait();

			this.KeyTopUpdateTokenSource=null;
			this.KeyTopUpdateTask=null;

		}

		/// <summary>
		/// キートップの表示を非同期にキャンセルします。
		/// </summary>
		internal async void KeyTopUpdataCancelAsync() {
			await Task.Run(new Action(this.KeyTopUpdataCancel));
		}

		#endregion

	}
}