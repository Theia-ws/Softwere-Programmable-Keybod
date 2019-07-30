using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class ErrorMessages:LoaderBase {
		[XmlElement("LoadMiss")]
		public string LoadMiss {
			get;
			set;
		}
		[XmlElement("ErrorPoint")]
		public string ErrorPoint {
			get;
			set;
		}
		[XmlElement("KeyMapSet")]
		public KeyMapSet KeyMapSet {
			get;
			set;
		} = new KeyMapSet();
		[XmlElement("KeyMap")]
		public KeyMap KeyMap {
			get;
			set;
		} = new KeyMap();
		[XmlElement("Key")]
		public Key Key {
			get;
			set;
		} =new Key();
		[XmlElement("InputData")]
		public InputData InputData {
			get;
			set;
		} = new InputData();
	}
}