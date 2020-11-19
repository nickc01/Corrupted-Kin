using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextOverlapCircle2d : FsmStateAction
	{
		public FsmOwnerDefault fromGameObject;
		public FsmVector2 fromPosition;
		public FsmFloat radius;
		public FsmInt minDepth;
		public FsmInt maxDepth;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmInt collidersCount;
		public FsmGameObject storeNextCollider;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
	}
}
