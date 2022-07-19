using System;
using System.IO;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1 {

	[Serializable]
	[XmlRoot("Config")]
	public class AppMasterConfig {

		internal static AppMasterConfig Load(string filePath) {
			FileStream fs=null;
			try {
				fs=new FileStream(filePath,FileMode.Open);
				var keyMapConfig = XmlSerializer.Deserialize(fs) as AppMasterConfig;
				keyMapConfig.ConfigFilePath=filePath;
				return keyMapConfig;
			} catch(Exception) {
				throw new LoadException();
			} finally {
				fs?.Dispose();
			}
		}

		internal static AppMasterConfig Create(string filePath) => new AppMasterConfig() {
			ConfigFilePath=filePath,
			KeyMapSetPath=Path.Combine(new string[] { Environment.CurrentDirectory,"Config","Theias config for Minecraft building" })
		};

		internal void Save() {
			StreamWriter streamWriter = null;
			try {
				streamWriter=new StreamWriter(this.ConfigFilePath,false,new System.Text.UTF8Encoding(false));
				XmlSerializer.Serialize(streamWriter,this);
			} catch(Exception ex) {
				throw new SaveException(ex.Message,ex);
			} finally {
				streamWriter?.Dispose();
			}
		}

		[XmlIgnore]
		internal string ConfigFilePath {
			get;
			private set;
		}

		[XmlIgnore]
		private static XmlSerializer XmlSerializer {
			get;
		} = new XmlSerializer(typeof(AppMasterConfig));

		[XmlElement("KeyMapSetPath")]
		public string KeyMapSetPath {
			get;
			set;
		}
	}
}