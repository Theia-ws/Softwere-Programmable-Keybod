using System;

namespace WS.Theia.Library.SendKeys {
	struct INPUT {
		public INPUT(ushort vk,ushort scan,KeyboardFlag flags,uint time,IntPtr extraInfo) {
			this.Type=1;
			this.Data=new MOUSEKEYBDHARDWAREINPUT(vk,scan,flags,time,extraInfo);
		}
		public uint Type;
		public MOUSEKEYBDHARDWAREINPUT Data;
	}
}