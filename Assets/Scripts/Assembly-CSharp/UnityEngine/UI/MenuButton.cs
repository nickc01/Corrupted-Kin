using UnityEngine;

namespace UnityEngine.UI
{
	public class MenuButton : MenuSelectable
	{
		public enum MenuButtonType
		{
			Proceed = 0,
			Activate = 1,
		}

		public MenuButtonType buttonType;
		public Animator flashEffect;
	}
}
