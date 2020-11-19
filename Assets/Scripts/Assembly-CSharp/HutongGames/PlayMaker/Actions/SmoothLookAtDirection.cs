using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothLookAtDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 targetDirection;
		public FsmFloat minMagnitude;
		public FsmVector3 upVector;
		public FsmBool keepVertical;
		public FsmFloat speed;
		public bool lateUpdate;
		public FsmEvent finishEvent;
		public FsmBool finish;
	}
}
