using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class InputData:LoaderBase {
		[XmlElement("AfterWateMinus")]
		public string AfterWateMinus {
			get;
			set;
		}
		[XmlElement("Index")]
		public Index Index {
			get;
			set;
		} = new Index();
	}
}