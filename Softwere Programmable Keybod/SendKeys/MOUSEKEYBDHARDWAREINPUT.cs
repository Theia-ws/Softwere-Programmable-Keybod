using System;
using System.Runtime.InteropServices;

namespace WS.Theia.Library.SendKeys {
	[StructLayout(LayoutKind.Explicit)]
	struct MOUSEKEYBDHARDWAREINPUT {
		public MOUSEKEYBDHARDWAREINPUT(ushort vk,ushort scan,KeyboardFlag flags,uint time,IntPtr extraInfo) : this() => this.Keyboard=new KEYBDINPUT(vk,scan,flags,time,extraInfo);

		[FieldOffset(0)]
		public MOUSEINPUT Mouse;

		[FieldOffset(0)]
		public KEYBDINPUT Keyboard;

	}
}