using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MoveTowards : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmVector3 targetPosition;
		public FsmBool ignoreVertical;
		public FsmFloat maxSpeed;
		public FsmFloat finishDistance;
		public FsmEvent finishEvent;
	}
}
