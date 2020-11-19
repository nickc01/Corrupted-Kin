using UnityEngine;

namespace InControl
{
	public class TouchStickControl : TouchControl
	{
		[SerializeField]
		private TouchControlAnchor anchor;
		[SerializeField]
		private TouchUnitType offsetUnitType;
		[SerializeField]
		private Vector2 offset;
		[SerializeField]
		private TouchUnitType areaUnitType;
		[SerializeField]
		private Rect activeArea;
		public TouchControl.AnalogTarget target;
		public TouchControl.SnapAngles snapAngles;
		public LockAxis lockToAxis;
		public float lowerDeadZone;
		public float upperDeadZone;
		public AnimationCurve inputCurve;
		public bool allowDragging;
		public DragAxis allowDraggingAxis;
		public bool snapToInitialTouch;
		public bool resetWhenDone;
		public float resetDuration;
		public TouchSprite ring;
		public TouchSprite knob;
		public float knobRange;
	}
}
