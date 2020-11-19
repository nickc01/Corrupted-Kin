using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TouchObjectEvent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat pickDistance;
		public FsmInt fingerId;
		public FsmEvent touchBegan;
		public FsmEvent touchMoved;
		public FsmEvent touchStationary;
		public FsmEvent touchEnded;
		public FsmEvent touchCanceled;
		public FsmInt storeFingerId;
		public FsmVector3 storeHitPoint;
		public FsmVector3 storeHitNormal;
	}
}
