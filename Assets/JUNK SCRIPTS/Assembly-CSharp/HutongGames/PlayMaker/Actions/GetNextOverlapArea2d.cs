using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextOverlapArea2d : FsmStateAction
	{
		public FsmOwnerDefault firstCornerGameObject;
		public FsmVector2 firstCornerPosition;
		public FsmGameObject secondCornerGameObject;
		public FsmVector2 secondCornerPosition;
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
