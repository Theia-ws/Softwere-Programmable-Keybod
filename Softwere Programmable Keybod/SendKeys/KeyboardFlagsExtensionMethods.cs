namespace WS.Theia.Library.SendKeys {
	internal static class KeyboardFlagsExtensionMethods {

		/*public static bool IsKeyDown(this KeyboardFlag value) {
			return !value.IsKeyUp();
		}
		public static bool IsExtendedKey(this KeyboardFlag value) {
			return value.Check(KeyboardFlag.ExtendedKey);
		}
		public static bool IsKeyUp(this KeyboardFlag value) {
			return value.Check(KeyboardFlag.KeyUp);
		}*/
		public static bool IsUnicode(this KeyboardFlag value) {
			return value.Check(KeyboardFlag.Unicode);
		}
		/*public static bool IsScanCode(this KeyboardFlag value) {
			return value.Check(KeyboardFlag.ScanCode);
		}*/

		private static bool Check(this KeyboardFlag targetValue,KeyboardFlag checkValue) {
			return (targetValue&checkValue)==checkValue;
		}
	}
}