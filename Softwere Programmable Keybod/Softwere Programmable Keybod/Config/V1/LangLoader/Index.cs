using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class Index:LoaderBase {
		[XmlElement("Minus")]
		public string Minus {
			get;
			set;
		}
		[XmlElement("Duplicate")]
		public string Duplicate {
			get;
			set;
		}
	}
}