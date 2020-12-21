using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TouchGUIEvent : FsmStateAction
	{
		public enum OffsetOptions
		{
			TopLeft = 0,
			Center = 1,
			TouchStart = 2,
		}

		public FsmOwnerDefault gameObject;
		public FsmInt fingerId;
		public FsmEvent touchBegan;
		public FsmEvent touchMoved;
		public FsmEvent touchStationary;
		public FsmEvent touchEnded;
		public FsmEvent touchCanceled;
		public FsmEvent notTouching;
		public FsmInt storeFingerId;
		public FsmVector3 storeHitPoint;
		public FsmBool normalizeHitPoint;
		public FsmVector3 storeOffset;
		public OffsetOptions relativeTo;
		public FsmBool normalizeOffset;
		public bool everyFrame;
	}
}
