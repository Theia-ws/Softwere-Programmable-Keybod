using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class KeyMapSet:LoaderBase {
		[XmlElement("WindowHeight")]
		public WindowHeight WindowHeight {
			get;
			set;
		} = new WindowHeight();
		[XmlElement("WindowWidth")]
		public WindowWidth WindowWidth {
			get;
			set;
		} = new WindowWidth();
		[XmlElement("KeyMapCheck")]
		public KeyMapCheck KeyMapCheck {
			get;
			set;
		} = new KeyMapCheck();
	}
}