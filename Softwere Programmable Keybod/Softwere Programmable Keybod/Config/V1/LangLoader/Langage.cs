using System;
using System.IO;
using System.Security;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	[XmlRoot("Language")]
	public class Language:LoaderBase {

		[XmlElement("Config")]
		public ConfigMessage Config {
			get;
			set;
		} = new ConfigMessage();

		[XmlElement("KeyMapSetLoder")]
		public KeyMapSetLoder KeyMapSetLoder {
			get;
			set;
		} = new KeyMapSetLoder();

		[XmlElement("ImportKeyMap")]
		public ImportKeyMap ImportKeyMap {
			get;
			set;
		} = new ImportKeyMap();

		[XmlElement("Notifyicon")]
		public Notifyicon Notifyicon {
			get;
			set;
		} = new Notifyicon();

		[XmlElement("ConfigExampleLoadMiss")]
		public string ConfigExampleLoadMiss {
			get;
			set;
		}

		internal static Language Load(string filePath) {
			FileStream fs = null;
			try {
				fs=new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				return new XmlSerializer(typeof(Language)).Deserialize(fs) as Language;
			} catch(Exception e) when(e is ArgumentException||e is NotSupportedException||e is ArgumentNullException||e is SecurityException||e is FileNotFoundException||e is IOException||e is DirectoryNotFoundException||e is PathTooLongException||e is ArgumentOutOfRangeException||e is InvalidOperationException) {
				return new Language();
			} finally {
				fs?.Dispose();
			}
		}
		internal Language AutoComplete(string autoCompleteLangPath) {
			this.AutoComplete(Load(autoCompleteLangPath));
			return this;
		}
	}
}