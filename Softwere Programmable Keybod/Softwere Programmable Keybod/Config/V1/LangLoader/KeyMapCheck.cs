using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class KeyMapCheck:LoaderBase {
		[XmlElement("ExtendsError")]
		public string ExtendsError {
			get;
			set;
		}
		[XmlElement("Null")]
		public string Null {
			get;
			set;
		}
		[XmlElement("DefaultMap")]
		public DefaultMap DefaultMap {
			get;
			set;
		} = new DefaultMap();
	}
}