using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextOverlapPoint2d : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 position;
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
