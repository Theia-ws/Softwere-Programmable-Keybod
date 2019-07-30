using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	public class Notifyicon:LoaderBase {

		[XmlElement("IconName")]
		public string IconName {
			get;
			set;
		}

		[XmlElement("ExampleConifg")]
		public string ExampleConifg {
			get;
			set;
		}

		[XmlElement("ImportKeyMap")]
		public string ImportKeyMap {
			get;
			set;
		}

		[XmlElement("SelectKeyMap")]
		public string SelectKeyMap {
			get;
			set;
		}

		[XmlElement("Exit")]
		public string Exit {
			get;
			set;
		}
	}
}