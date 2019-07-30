using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class DefaultMap:LoaderBase {
		[XmlElement("Zero")]
		public string Zero {
			get;
			set;
		}
		[XmlElement("Over")]
		public string Over {
			get;
			set;
		}
	}
}