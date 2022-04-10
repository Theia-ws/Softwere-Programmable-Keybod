using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1;
using WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.DefineImport;
using Window = System.Windows.Window;

namespace WS.Theia.Tool.SoftwereProgrammableKeybod {
	class NotifyIcon:IDisposable {

		internal Window MainWindow {
			get;
			set;
		}
		private readonly System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
		private readonly ContextMenuStrip menuStrip = new ContextMenuStrip();
		private readonly ToolStripMenuItem exampleConfig = new ToolStripMenuItem();
		private readonly ToolStripMenuItem importKeymap = new ToolStripMenuItem();
		private readonly ToolStripMenuItem configSelect = new ToolStripMenuItem();
		private ToolStripMenuItem[] keyMapMenuItemList = null;
		private readonly ToolStripMenuItem exitItem = new ToolStripMenuItem();



		internal NotifyIcon() {

			_=this.menuStrip.Items.Add(this.MakeConfigExample());

			_=this.menuStrip.Items.Add(this.MakeImportKeyMap());

			_=this.menuStrip.Items.Add(this.MakeConfigSelect());

			_=this.menuStrip.Items.Add(this.MakeExit());

			this.notifyIcon.ContextMenuStrip=menuStrip;
			this.notifyIcon.Icon=new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("WS.Theia.Tool.SoftwereProgrammableKeybod.icon.ico"));
			this.notifyIcon.Visible=true;
			this.notifyIcon.Text=App.Language.Notifyicon.IconName;

			this.notifyIcon.MouseClick+=new MouseEventHandler((object sender,MouseEventArgs e) => this.MainWindow?.Show());

		}

		private ToolStripMenuItem MakeConfigExample() {

			this.exampleConfig.Text=App.Language.Notifyicon.ExampleConifg;
			this.exampleConfig.Click+=new EventHandler(this.ExampleConfig_Clock);

			return this.exampleConfig;

		}
		private void ExampleConfig_Clock(object sender,EventArgs e) => new ConfigExample().Show();

		private ToolStripMenuItem MakeImportKeyMap() {

			this.importKeymap.Text=App.Language.Notifyicon.ImportKeyMap;
			this.importKeymap.Click+=new EventHandler(this.ImportKeyMap_Clock);

			return this.importKeymap;
		}

		private void ImportKeyMap_Clock(object sender,EventArgs e) {
			try {
				new ImportWindow().ShowDialog(this.MainWindow);
				this.configSelect.DropDownItems.Clear();
				_=this.MakeConfigSelect();
			} catch(ImportExceptionBase) {
			} catch(LoadException) {
			}
		}

		private ToolStripMenuItem MakeConfigSelect() {

			this.configSelect.Text=App.Language.Notifyicon.SelectKeyMap;
			this.configSelect.DropDownItems.AddRange(this.GetConfigList());

			return configSelect;

		}

		private ToolStripMenuItem[] GetConfigList() {

			if(this.keyMapMenuItemList!=null) {
				foreach(var keyMapMenuItem in this.keyMapMenuItemList) {
					keyMapMenuItem.Dispose();
				}
			}
			if(App.DefineManager.FileList==null) {
				App.DefineManager.Update();
			}
			this.keyMapMenuItemList=new ToolStripMenuItem[App.DefineManager.FileList.Count];
			var keyMapFileListCounter = 0;
			foreach(var keyMap in App.DefineManager.FileList) {

				this.keyMapMenuItemList[keyMapFileListCounter]=new ToolStripMenuItem();
				this.keyMapMenuItemList[keyMapFileListCounter].Click+=new EventHandler(this.CinfigCheenge_Clock);
				this.keyMapMenuItemList[keyMapFileListCounter].Text=keyMap.Value;
				this.keyMapMenuItemList[keyMapFileListCounter].Name=keyMap.Key;
				if(App.Config.KeyMapSetPath==this.keyMapMenuItemList[keyMapFileListCounter].Name) {
					this.keyMapMenuItemList[keyMapFileListCounter].CheckState=CheckState.Indeterminate;
				}
				keyMapFileListCounter++;
			}

			return this.keyMapMenuItemList;

		}

		private void CinfigCheenge_Clock(object sender,EventArgs e) {

			var senderItem = sender as ToolStripMenuItem;
			if(senderItem.CheckState==CheckState.Indeterminate) {
				return;
			}
			foreach(var item in senderItem.GetCurrentParent().Items) {
				((ToolStripMenuItem)item).CheckState=CheckState.Unchecked;
			}
			senderItem.CheckState=CheckState.Indeterminate;
			try {
				App.DefineManager.Load(senderItem.Name);
			} catch(LoadException) {
			}

		}

		private ToolStripMenuItem MakeExit() {

			this.exitItem.Text=App.Language.Notifyicon.Exit;
			this.exitItem.Click+=new EventHandler(this.Exit_Click);

			return this.exitItem;

		}

		private void Exit_Click(object sender,EventArgs e) {

			notifyIcon.Visible=false;

			this.MainWindow?.Close();


		}

		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if(disposing) {
				this.exampleConfig.Dispose();
				this.importKeymap.Dispose();
				this.configSelect.Dispose();
				if(this.keyMapMenuItemList!=null) {
					foreach(var keyMapMenuItem in this.keyMapMenuItemList) {
						keyMapMenuItem.Dispose();
					}
				}
				this.exitItem.Dispose();
				this.menuStrip.Dispose();
				this.notifyIcon.Dispose();
			}
		}

		~NotifyIcon() {
			this.Dispose(false);
		}


	}
}