using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class RayCast2d : FsmStateAction
	{
		public FsmOwnerDefault fromGameObject;
		public FsmVector2 fromPosition;
		public FsmVector2 direction;
		public Space space;
		public FsmFloat distance;
		public FsmInt minDepth;
		public FsmInt maxDepth;
		public FsmEvent hitEvent;
		public FsmBool storeDidHit;
		public FsmGameObject storeHitObject;
		public FsmVector2 storeHitPoint;
		public FsmVector2 storeHitNormal;
		public FsmFloat storeHitDistance;
		public FsmFloat storeHitFraction;
		public FsmInt repeatInterval;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmColor debugColor;
		public FsmBool debug;
	}
}
