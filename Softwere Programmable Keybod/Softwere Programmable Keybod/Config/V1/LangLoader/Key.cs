using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class Key:LoaderBase {
		[XmlElement("NoAflterMap")]
		public string NoAflterMap {
			get;
			set;
		}
		[XmlElement("Height")]
		public Height Height {
			get;
			set;
		} = new Height();
		[XmlElement("Width")]
		public Width Width {
			get;
			set;
		} = new Width();
	}
}