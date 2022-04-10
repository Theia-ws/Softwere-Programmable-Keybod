using System;

namespace WS.Theia.Library.SendKeys.KeyParse {
	class NormalLoop:Normal {
		public NormalLoop(char? checkValue,EventHandler match,KeyboardFlag keyPressCode,char vkOrScanCode,Base[] nextCheck) : base(checkValue,match,keyPressCode,vkOrScanCode,nextCheck) {
		}

		protected override (int loopLength, int nextCharCounter) GetLoopLength(char[] chars,int charCounter) {

			var loopLength = 0;
			var state = false;
			for(;int.TryParse(chars[charCounter].ToString(),out var parcedVal);charCounter++) {
				state=true;
				loopLength*=10;
				loopLength+=parcedVal;
			}

			return !state||chars[charCounter]!='}' ? throw new ArgumentException("keys 有効なキー入力ではありません。",nameof(chars)) : (loopLength, ++charCounter);

		}
	}
}