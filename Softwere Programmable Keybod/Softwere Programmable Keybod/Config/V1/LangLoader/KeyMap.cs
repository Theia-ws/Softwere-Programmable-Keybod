using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class KeyMap:LoaderBase {
		[XmlElement("Height")]
		public string Height {
			get;
			set;
		}
		[XmlElement("NoExtendsMap")]
		public string NoExtendsMap {
			get;
			set;
		}
		[XmlElement("NoName")]
		public string NoName {
			get;
			set;
		}
		[XmlElement("Width")]
		public string Width {
			get;
			set;
		}
	}
}