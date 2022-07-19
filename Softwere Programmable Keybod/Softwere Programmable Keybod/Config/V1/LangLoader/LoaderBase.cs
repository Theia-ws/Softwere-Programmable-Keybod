namespace WS.Theia.Tool.SoftwereProgrammableKeybod.Config.V1.LangLoader {
	public abstract class LoaderBase {

		internal void AutoComplete(LoaderBase autoCompleteBase) {
			if(autoCompleteBase==null) {
				return;
			}

			foreach(var member in autoCompleteBase.GetType().GetProperties()) {
				if(member.PropertyType==typeof(string)) {
					if(string.IsNullOrEmpty(member.GetValue(this)?.ToString())) {
						member.SetValue(this,member.GetValue(autoCompleteBase));
					}
				} else {
					(member.GetValue(this) as LoaderBase)?.AutoComplete(member.GetValue(autoCompleteBase) as LoaderBase);
				}
			}
		}
	}
}