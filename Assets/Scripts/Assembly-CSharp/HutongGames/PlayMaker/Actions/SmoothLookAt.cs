using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothLookAt : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmVector3 targetPosition;
		public FsmVector3 upVector;
		public FsmBool keepVertical;
		public FsmFloat speed;
		public FsmBool debug;
		public FsmFloat finishTolerance;
		public FsmEvent finishEvent;
	}
}
