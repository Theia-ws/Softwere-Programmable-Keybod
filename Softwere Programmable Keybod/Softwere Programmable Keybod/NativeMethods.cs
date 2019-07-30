using System;
using System.Runtime.InteropServices;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod {
	static class NativeMethods {

		internal static bool SetNotActiveWindow(IntPtr hWnd) {
			if(SetWindowLong(hWnd,GWL.EXSTYLE,GetWindowLong(hWnd,GWL.EXSTYLE)|WS_EX_NOACTIVATE)==0&&0!=Marshal.GetLastWin32Error()) {
					return false;
			}
			if(SetWindowPos(hWnd,IntPtr.Zero,0,0,0,0,SWP.NOMOVE|SWP.NOSIZE|SWP.NOZORDER|SWP.FRAMECHANGED)==0&&0!=Marshal.GetLastWin32Error()) {
					return false;
			}
			return true;
		}

		const UInt32 WS_EX_NOACTIVATE = 0x8000000;

		private enum GWL:int {
			WINDPROC = -4,
			HINSTANCE = -6,
			HWNDPARENT = -8,
			STYLE = -16,
			EXSTYLE = -20,
			USERDATA = -21,
			ID = -12
		}

		private enum SWP:int {
			NOSIZE = 0x0001,
			NOMOVE = 0x0002,
			NOZORDER = 0x0004,
			NOREDRAW = 0x0008,
			NOACTIVATE = 0x0010,
			FRAMECHANGED = 0x0020,
			SHOWWINDOW = 0x0040,
			HIDEWINDOW = 0x0080,
			NOCOPYBITS = 0x0100,
			NOOWNERZORDER = 0x0200,
			NOSENDCHANGING = 0x400
		}

		[DllImport("user32.dll")]
		private static extern UInt32 GetWindowLong(IntPtr hWnd,GWL index);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern UInt32 SetWindowLong(IntPtr hWnd,GWL index,UInt32 unValue);

		[DllImport("user32.dll",SetLastError = true)]
		private static extern UInt32 SetWindowPos(IntPtr hWnd,IntPtr hWndInsertAfter,int x,int y,int width,int height,SWP flags);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetForegroundWindow();

		[DllImport("USER32.DLL")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetForegroundWindow(IntPtr hWnd);

	}
}