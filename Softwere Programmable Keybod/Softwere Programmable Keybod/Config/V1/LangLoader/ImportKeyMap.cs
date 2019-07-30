using System;
using System.Xml.Serialization;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	[Serializable]
	public class ImportKeyMap:LoaderBase {

		[XmlElement("DialogFilter")]
		public string DialogFilter {
			get;
			set;
		}

		[XmlElement("XmlNotFound")]
		public string XmlNotFound {
			get;
			set;
		}

		[XmlElement("Successful")]
		public string Successful {
			get;
			set;
		}

		[XmlElement("CannotOpenZipFile")]
		public string CannotOpenZipFile {
			get;
			set;
		}

		[XmlElement("CannotXamlConvert")]
		public string CannotXamlConvert {
			get;
			set;
		}

		[XmlElement("UNZipProgressMessage")]
		public string UNZipProgressMessage {
			get;
			set;
		}

		[XmlElement("SvgSearchMessage")]
		public string SvgSearchMessage {
			get;
			set;
		}

		[XmlElement("Svg2XamlConvertMessage")]
		public string Svg2XamlConvertMessage {
			get;
			set;
		}

		[XmlElement("OldClearQ")]
		public string OldClearQ {
			get;
			set;
		}
		[XmlElement("OldClearCancel")]
		public string OldClearCancel {
			get;
			set;
		}
	}
}