namespace WS.Theia.Library.SendKeys.KeyParse {
	class Normal:Base {
		public Normal(char? checkValue,EventHandler match,KeyboardFlag keyPressCode,char vkOrScanCode,Base[] nextCheck) : base(checkValue,match,keyPressCode,vkOrScanCode,nextCheck) {
		}
		protected override int MakeInputList(char[] chars,int charCounter,ushort keyCode,ParsedTree piarent) {
			int loopLength;
			(loopLength, charCounter)=this.GetLoopLength(chars,charCounter);
			this.MakeInputList(keyCode,loopLength,piarent);
			return charCounter;
		}
	}
}