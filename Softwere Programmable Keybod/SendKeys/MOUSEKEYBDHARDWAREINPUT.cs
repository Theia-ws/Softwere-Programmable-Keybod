using System;
using System.Runtime.InteropServices;

namespace WS.Theia.Library.SendKeys {
	[StructLayout(LayoutKind.Explicit)]
	struct MOUSEKEYBDHARDWAREINPUT {
		public MOUSEKEYBDHARDWAREINPUT(ushort vk,ushort scan,KeyboardFlag flags,uint time,IntPtr extraInfo) : this() {
			this.Keyboard=new KEYBDINPUT(vk,scan,flags,time,extraInfo);
		}
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance","CA1823:AvoidUnusedPrivateFields")]
		[FieldOffset(0)]
		public MOUSEINPUT Mouse;
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance","CA1823:AvoidUnusedPrivateFields")]
		[FieldOffset(0)]
		public KEYBDINPUT Keyboard;

	}
}