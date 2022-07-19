using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class ConfigMessage:LoaderBase {
		[XmlElement("FalidSave")]
		public string FalidSave {
			get;
			set;
		}
	}
}