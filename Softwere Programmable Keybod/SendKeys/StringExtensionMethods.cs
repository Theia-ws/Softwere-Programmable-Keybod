using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Globalization;
using WS.Theia.Library.SendKeys.KeyParse;

namespace WS.Theia.Library.SendKeys {
	/// <summary>
	/// 
	/// </summary>
	public static class StringExtensionMethods {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		public static void SendKeys(this string text) {

			if(text==null) {
				throw new ArgumentNullException(nameof(text));
			}

			var textLength = text.Length;

			if(textLength>uint.MaxValue/2) {
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,"The text parameter is too long. It must be less than {0} characters.",uint.MaxValue/2),nameof(text));
			}

			var chars = text.ToCharArray();
			var charsCounter = 0;
			var parsedTree = ParsedTree.CreateRoot();

			while(charsCounter<textLength) {
				try {
					charsCounter=Base.Parse(chars,charsCounter,parsedTree);
				} catch(Exception ex) when(ex is ArgumentException||ex is IndexOutOfRangeException) {
					throw new ArgumentException("keys 有効なキー入力ではありません。"+Environment.NewLine+ex.ToString(),nameof(text),ex);
				}
			}

			var inputList = new List<List<INPUT>> {
				new List<INPUT>()
			};
			Convert(parsedTree,inputList);

			foreach(var iList in inputList) {
				if(NativeMethods.SendInputRapper((uint)iList.Count,iList.ToArray(),Marshal.SizeOf(typeof(INPUT)))==0) {
					throw new InvalidOperationException("アクティブなアプリケーションにキーストロークを送信することはありません。");
				}
			}
		}

		//TODO:再起処理のループ化を行う事
		private static void Convert(ParsedTree parsedTree,List<List<INPUT>> inputList) {
			foreach(var addInput in parsedTree) {

				var loopEnd = addInput.LoopLength-1;
				for(var loopCounter = 0;loopCounter<loopEnd;loopCounter++) {
					GetDown(addInput,inputList);
					GetUp(addInput,inputList);
				}

				if(addInput.LoopLength>0) {
					GetDown(addInput,inputList);					
					Convert(addInput,inputList);
					GetUp(addInput,inputList);
				} else {
					Convert(addInput,inputList);
				}

			}
		}

		private static void GetDown(ParsedTree addInput,List<List<INPUT>> inputList) {
			foreach(var ickPre in addInput.ICKPre) {
				ListUpdateCheck(inputList).Add(ickPre);
			}
			ListUpdateCheck(inputList).Add(addInput.KeyDown);
		}
		private static void GetUp(ParsedTree addInput,List<List<INPUT>> inputList) {
			ListUpdateCheck(inputList).Add(addInput.KeyUp);
			foreach(var ickAfter in addInput.ICKAfter) {
				ListUpdateCheck(inputList).Add(ickAfter);
			}
		}

		private static List<INPUT> ListUpdateCheck(List<List<INPUT>> inputList) {
			var addTargetList = inputList[inputList.Count-1];
			if(addTargetList.Count>=int.MaxValue) {
				addTargetList=new List<INPUT>();
				inputList.Add(addTargetList);
			}
			return addTargetList;
		}

	}

}