using System;

namespace WS.Theia.Library.SendKeys {
	[Flags]
	internal enum KeyboardFlag:uint {
		KeyDown = 0x0000,
		ExtendedKey = 0x0001,
		KeyUp = 0x0002,
		Unicode = 0x0004,
		ScanCode = 0x0008,
	}
}