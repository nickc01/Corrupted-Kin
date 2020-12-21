using UnityEngine;

namespace InControl
{
	public class TouchSwipeControl : TouchControl
	{
		[SerializeField]
		private TouchUnitType areaUnitType;
		[SerializeField]
		private Rect activeArea;
		public float sensitivity;
		public bool oneSwipePerTouch;
		public TouchControl.AnalogTarget target;
		public TouchControl.SnapAngles snapAngles;
		public TouchControl.ButtonTarget upTarget;
		public TouchControl.ButtonTarget downTarget;
		public TouchControl.ButtonTarget leftTarget;
		public TouchControl.ButtonTarget rightTarget;
		public TouchControl.ButtonTarget tapTarget;
	}
}
