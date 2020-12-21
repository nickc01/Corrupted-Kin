using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextLineCast2d : FsmStateAction
	{
		public FsmOwnerDefault fromGameObject;
		public FsmVector2 fromPosition;
		public FsmGameObject toGameObject;
		public FsmVector2 toPosition;
		public FsmInt minDepth;
		public FsmInt maxDepth;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmInt collidersCount;
		public FsmGameObject storeNextCollider;
		public FsmVector2 storeNextHitPoint;
		public FsmVector2 storeNextHitNormal;
		public FsmFloat storeNextHitDistance;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
	}
}
