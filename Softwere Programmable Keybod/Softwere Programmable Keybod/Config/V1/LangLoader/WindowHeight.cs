using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class WindowHeight:LoaderBase {
		[XmlElement("Zero")]
		public string Zero {
			get;
			set;
		}
		[XmlElement("Minus")]
		public string Minus {
			get;
			set;
		}
	}
}