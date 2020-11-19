namespace UnityEngine.UI
{
	public class MenuOptionHorizontal : MenuSelectable
	{
		public enum ApplyOnType
		{
			Scroll = 0,
			Submit = 1,
		}

		public Text optionText;
		public string[] optionList;
		public int selectedOptionIndex;
		public MenuSetting menuSetting;
		public ApplyOnType applySettingOn;
		public bool localizeText;
		public string sheetTitle;
	}
}
