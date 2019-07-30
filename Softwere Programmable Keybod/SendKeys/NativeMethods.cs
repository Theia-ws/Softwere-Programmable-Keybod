using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace WS.Theia.Library.SendKeys {
	static class NativeMethods {
		public static uint SendInputRapper(uint nInputs,INPUT[] pInputs,int cbSize) {
#if DEBUG
			foreach(var input in pInputs) {
				var keyInput = input.Data.Keyboard;
				System.Diagnostics.Debug.Write("wVk:"+keyInput.Vk.ToString("X2",System.Globalization.CultureInfo.CurrentCulture)+";");
				System.Diagnostics.Debug.Write("wScan:"+keyInput.Scan+";");
				System.Diagnostics.Debug.Write("dwFlags:"+keyInput.Flags+";");
				System.Diagnostics.Debug.Write("time:"+keyInput.Time+";");
				System.Diagnostics.Debug.WriteLine("dwExtraInfo:"+keyInput.ExtraInfo+";");
			}
#endif
			return SendInput(nInputs,pInputs,cbSize);
		}
		[DllImport("user32.dll",SetLastError = true)]
		public static extern uint SendInput(uint numberOfInputs,INPUT[] inputs,int sizeOfInputStructure);
		[DllImport("user32.dll",CharSet = CharSet.Auto)]
		[ResourceExposure(ResourceScope.None)]
		public static extern short VkKeyScan(char key);
	}
}