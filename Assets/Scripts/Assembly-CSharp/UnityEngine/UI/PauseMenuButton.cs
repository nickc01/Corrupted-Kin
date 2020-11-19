using UnityEngine;

namespace UnityEngine.UI
{
	public class PauseMenuButton : MenuSelectable
	{
		public enum PauseButtonType
		{
			Continue = 0,
			Options = 1,
			Quit = 2,
		}

		public Animator flashEffect;
		public PauseButtonType pauseButtonType;
	}
}
