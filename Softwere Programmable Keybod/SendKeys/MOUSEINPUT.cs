using System;

namespace WS.Theia.Library.SendKeys {
#pragma warning disable 649
	struct MOUSEINPUT {
		public int X;
		public int Y;
		public uint MouseData;
		public uint Flags;
		public uint Time;
		public IntPtr ExtraInfo;
	}
#pragma warning restore 649
}