using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WS.Theia.Library.SendKeys.KeyParse {
	class ParsedTree:Collection<ParsedTree> {

		private const int SHIFTKEYSCAN = 0x0100;
		private const int CTRLKEYSCAN = 0x0200;
		private const int ALTKEYSCAN = 0x0400;

		private ParsedTree() {
			this.Piarent=null;
			this.LoopLength=0;
		}

		private ParsedTree(ParsedTree piarent,INPUT keyDown,INPUT keyUp,int loopLength) {
			this.Piarent=piarent;
			this.Piarent.Add(this);
			this.LoopLength=loopLength;
			this.KeyDown=keyDown;
			this.KeyUp=keyUp;
		}

		internal static ParsedTree CreateRoot() {
			return new ParsedTree();
		}

		internal static ParsedTree Create(ParsedTree piarent,ushort keyCode,KeyboardFlag flags,int loopLength) {
			if(!flags.IsUnicode()) {
				return new ParsedTree(piarent,new INPUT(keyCode,0,flags|KeyboardFlag.KeyDown,0,IntPtr.Zero),new INPUT(keyCode,0,flags|KeyboardFlag.KeyUp,0,IntPtr.Zero),loopLength);
			}
			var vk = NativeMethods.VkKeyScan((char)keyCode);
			if(vk==-1) {
				if((keyCode&0xFF00)==0xE000) {
					flags=KeyboardFlag.ExtendedKey|flags;
				}
				return new ParsedTree(piarent,new INPUT(0,keyCode,flags|KeyboardFlag.KeyDown,0,IntPtr.Zero),new INPUT(0,keyCode,flags|KeyboardFlag.KeyUp,0,IntPtr.Zero),loopLength);
			}
			var baseVk = (ushort)(vk&0x00ff);
			flags=flags^KeyboardFlag.Unicode;
			return new ParsedTree(piarent,new INPUT(baseVk,0,flags|KeyboardFlag.KeyDown,0,IntPtr.Zero),new INPUT(baseVk,0,flags|KeyboardFlag.KeyUp,0,IntPtr.Zero),loopLength).ICKAdd(vk,SHIFTKEYSCAN,VK.VK_SHIFT).ICKAdd(vk,CTRLKEYSCAN,VK.VK_CONTROL).ICKAdd(vk,ALTKEYSCAN,VK.VK_MENU);
		}

		private ParsedTree ICKAdd(short checkVk,int mask,VK addingVk) {
			if((checkVk&mask)!=0&&!(this.Piarent?.IsPressed((ushort)addingVk)??false)) {
				this.ICKPre.Add(new INPUT((ushort)addingVk,0,KeyboardFlag.KeyDown,0,IntPtr.Zero));
				this.ICKAfter.Insert(0,new INPUT((ushort)addingVk,0,KeyboardFlag.KeyUp,0,IntPtr.Zero));
			}
			return this;
		}

		internal int LoopLength {
			get;
		}

		internal INPUT KeyDown {
			get;
		}

		internal INPUT KeyUp {
			get;
		}

		internal List<INPUT> ICKPre {
			get;
		} = new List<INPUT>();

		internal List<INPUT> ICKAfter {
			get;
		} = new List<INPUT>();

		internal ParsedTree Piarent {
			get;
		}

		internal bool IsPressed(ushort compareValue) {
			var target = this;

			while(target!=null) {
				if(target.LoopLength>0) {
					if(target.KeyDown.Data.Keyboard.Vk==compareValue) {
						return true;
					}
					foreach(var ick in target.ICKPre) {
						if(ick.Data.Keyboard.Vk==compareValue) {
							return true;
						}
					}
				}
				target=target.Piarent;
			}
			return false;
		}

	}
}