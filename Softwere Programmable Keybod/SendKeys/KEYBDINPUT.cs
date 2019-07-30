using System;

namespace WS.Theia.Library.SendKeys {
	struct KEYBDINPUT {
		public KEYBDINPUT(ushort vk,ushort scan,KeyboardFlag flags,uint time,IntPtr extraInfo) {
			this.Vk=vk;
			this.Scan=scan;
			this.Flags=(uint)flags;
			this.Time=time;
			this.ExtraInfo=extraInfo;
		}
		public ushort Vk;
		public ushort Scan;
		public uint Flags;
		public uint Time;
		public IntPtr ExtraInfo;
	}
}