using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class KeyMapSetLoder:LoaderBase {
		[XmlElement("ErrorMessages")]
		public ErrorMessages ErrorMessages {
			get;
			set;
		} = new ErrorMessages();
	}
}
