using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LineCast2d : FsmStateAction
	{
		public FsmOwnerDefault fromGameObject;
		public FsmVector2 fromPosition;
		public FsmGameObject toGameObject;
		public FsmVector2 toPosition;
		public FsmInt minDepth;
		public FsmInt maxDepth;
		public FsmEvent hitEvent;
		public FsmBool storeDidHit;
		public FsmGameObject storeHitObject;
		public FsmVector2 storeHitPoint;
		public FsmVector2 storeHitNormal;
		public FsmFloat storeHitDistance;
		public FsmInt repeatInterval;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmColor debugColor;
		public FsmBool debug;
	}
}
