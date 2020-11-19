using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextRayCast2d : FsmStateAction
	{
		public FsmOwnerDefault fromGameObject;
		public FsmVector2 fromPosition;
		public FsmVector2 direction;
		public Space space;
		public FsmFloat distance;
		public FsmInt minDepth;
		public FsmInt maxDepth;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmInt collidersCount;
		public FsmGameObject storeNextCollider;
		public FsmVector2 storeNextHitPoint;
		public FsmVector2 storeNextHitNormal;
		public FsmFloat storeNextHitDistance;
		public FsmFloat storeNextHitFraction;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
	}
}
