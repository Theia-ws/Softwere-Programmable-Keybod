namespace WS.Theia.Library.SendKeys.KeyParse {
	class Combination:Base {
		public Combination(char? checkValue,EventHandler match,KeyboardFlag keyPressCode,char vkOrScanCode,Base[] nextCheck) : base(checkValue,match,keyPressCode,vkOrScanCode,nextCheck) {
		}
		protected override int MakeInputList(char[] chars,int charCounter,ushort keyCode,ParsedTree piarent) {
			int loopLength;
			(loopLength, charCounter)=this.GetLoopLength(chars,charCounter);
			if(chars.Length>charCounter) {
				return this.MakeConbinationKeyInputList(chars,charCounter,keyCode,loopLength,piarent);
			}
			this.MakeInputList(keyCode,loopLength,piarent);
			return charCounter;
		}

		protected int MakeConbinationKeyInputList(char[] chars,int charCounter,ushort keyCode,int loopLength,ParsedTree piarent) {

			charCounter=loopLength>0&&!piarent.IsPressed(keyCode) ? MakeBaseKeyInputList(chars,charCounter,ParsedTree.Create(piarent,this.VkOrScanCode,this.KeyPressCode,loopLength)) : MakeBaseKeyInputList(chars,charCounter,piarent);
			return charCounter;

		}

		//TODO:再起処理のループ化を行う事（これが一番難易度高い）
		protected static int MakeBaseKeyInputList(char[] chars,int charCounter,ParsedTree piarent) {
			if(chars[charCounter]=='(') {
				charCounter++;
				charCounter=Parse(chars,charCounter,piarent);
				while(chars[charCounter]!=')') {
					charCounter=Parse(chars,charCounter,piarent);
				}
				charCounter++;
			} else {
				charCounter=Parse(chars,charCounter,piarent);
			}
			return charCounter;
		}

	}
}