using System;

namespace WS.Theia.Library.SendKeys.KeyParse {
	abstract partial class Base {

		public Base(char? checkValue,EventHandler match,KeyboardFlag keyPressCode,char vkOrScanCode,Base[] nextCheck) {
			this.CheckValue=checkValue;
			this.Match=match;
			this.KeyPressCode=keyPressCode;
			this.VkOrScanCode=vkOrScanCode;
			this.NextCheck=nextCheck;

		}

		protected char? CheckValue {
			get;
		}

		protected EventHandler Match;
		public delegate char? EventHandler(Base keyParseInfo,char[] chars,int charCounter);

		protected KeyboardFlag KeyPressCode {
			get;
		}

		protected char VkOrScanCode {
			get;
		}

		protected Base[] NextCheck {
			get;
		}

		public static int Parse(char[] chars,int charCounter,ParsedTree piarent) {

			ushort keyCode;
			var targetList = ConbinationKeyParseInfoList;

			while(targetList!=null) {
				foreach(var target in targetList) {
					if(target.CheckValue==null) {
						keyCode=target.Match?.Invoke(target,chars,charCounter)??chars[charCounter];
					} else if(target.CheckValue!=chars[charCounter]) {
						continue;
					} else {
						keyCode=target.Match?.Invoke(target,chars,charCounter)??target.VkOrScanCode;
					}
					charCounter++;
					if(target.NextCheck==null) {
						return target.MakeInputList(chars,charCounter,keyCode,piarent);
					}
					targetList=target.NextCheck;
					break;
				}
			}
			throw new ArgumentException("keys 有効なキー入力ではありません。",nameof(chars));
		}




		protected abstract int MakeInputList(char[] chars,int charCounter,ushort keyCode,ParsedTree piarent);

		protected virtual (int loopLength, int nextCharCounter) GetLoopLength(char[] chars,int charCounter) {
			return (1, charCounter);
		}

		protected void MakeInputList(ushort keyCode,int loopLength,ParsedTree piarent) {
			ParsedTree.Create(piarent,keyCode,this.KeyPressCode,loopLength);
		}

	}
}