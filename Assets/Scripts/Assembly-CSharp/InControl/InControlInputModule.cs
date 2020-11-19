using UnityEngine.EventSystems;

namespace InControl
{
	public class InControlInputModule : StandaloneInputModule
	{
		public enum Button
		{
			Action1 = 19,
			Action2 = 20,
			Action3 = 21,
			Action4 = 22,
		}

		public new Button submitButton;
		public new Button cancelButton;
		public float analogMoveThreshold;
		public float moveRepeatFirstDuration;
		public float moveRepeatDelayDuration;
		public new bool forceModuleActive;
		public bool allowMouseInput;
		public bool focusOnMouseHover;
	}
}
