using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothLookAt2d : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmVector2 targetPosition2d;
		public FsmVector3 targetPosition;
		public FsmFloat rotationOffset;
		public FsmFloat speed;
		public FsmBool debug;
		public FsmFloat finishTolerance;
		public FsmEvent finishEvent;
	}
}
