using UnityEngine;

namespace InControl
{
	public class TouchButtonControl : TouchControl
	{
		[SerializeField]
		private TouchControlAnchor anchor;
		[SerializeField]
		private TouchUnitType offsetUnitType;
		[SerializeField]
		private Vector2 offset;
		[SerializeField]
		private bool lockAspectRatio;
		public TouchControl.ButtonTarget target;
		public bool allowSlideToggle;
		public bool toggleOnLeave;
		public bool pressureSensitive;
		public TouchSprite button;
	}
}
