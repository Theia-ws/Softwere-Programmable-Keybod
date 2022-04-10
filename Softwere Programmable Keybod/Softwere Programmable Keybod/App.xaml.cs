using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod {
	public partial class App:System.Windows.Application {

		/// <summary>
		/// 設定情報を取得します。
		/// </summary>
		internal static AppMasterConfig Config {
			get;
		} = LoadConfig(Path.Combine(Application.LocalUserAppDataPath,"Config.xml"));

		/// <summary>
		/// 設定情報を読み込みます。
		/// </summary>
		/// <param name="configPath">設定ファイルのファイルパスを示す文字列。</param>
		/// <returns>設定情報のインスタンス</returns>
		private static AppMasterConfig LoadConfig(string configPath) {
			if(File.Exists(configPath)) {
				try {
					return AppMasterConfig.Load(configPath);
				} catch(LoadException) {
					return CreateConfig(configPath);
				}
			} else {
				return CreateConfig(configPath);
			}
		}

		/// <summary>
		/// 設定ファイルを作成・保存します。
		/// </summary>
		/// <param name="configPath">設定ファイルのファイルパスを示す文字列。</param>
		/// <returns>設定情報のインスタンス</returns>
		private static AppMasterConfig CreateConfig(string configPath) => SaveConfig(AppMasterConfig.Create(configPath));

		/// <summary>
		/// 設定ファイルを作成・保存します。
		/// </summary>
		/// <param name="configPath">設定ファイルのファイルパスを示す文字列。</param>
		/// <returns>設定情報のインスタンス</returns>
		private static AppMasterConfig SaveConfig(AppMasterConfig config) {
			try {
				config.Save();
			} catch(SaveException ex) {
				_=MessageBox.Show(Language.Config.FalidSave+Environment.NewLine+ex.Message,Language.Config.FalidSave,MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly|(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ? MessageBoxOptions.RtlReading : 0));
			}
			return config;
		}

		/// <summary>
		/// 言語情報を取得します。
		/// </summary>
		internal static Language Language {
			get;
		} = Language.Load(Path.Combine(Environment.CurrentDirectory,"Config","Lang",CultureInfo.CurrentCulture.ToString()+".xml")).AutoComplete(Path.Combine(Environment.CurrentDirectory,"Config","Lang","ja-JP.xml"));

		/// <summary>
		/// 定義マネージャを取得または設定します。
		/// </summary>
		internal static DefineManager DefineManager {
			get;
		} = new DefineManager();

		/// <summary>
		/// 通知領域アイコンを取得または設定します。
		/// </summary>
		internal static NotifyIcon NotifyIcon {
			get;
		} = new NotifyIcon();


	}
}