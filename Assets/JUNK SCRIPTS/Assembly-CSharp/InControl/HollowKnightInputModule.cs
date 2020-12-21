using UnityEngine.EventSystems;

namespace InControl
{
	public class HollowKnightInputModule : StandaloneInputModule
	{
		public float analogMoveThreshold;
		public float moveRepeatFirstDuration;
		public float moveRepeatDelayDuration;
		public new bool forceModuleActive;
		public bool allowMouseInput;
		public bool focusOnMouseHover;
	}
}
