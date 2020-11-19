using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CollisionEvent : FsmStateAction
	{
		public CollisionType collision;
		public FsmString collideTag;
		public FsmEvent sendEvent;
		public FsmGameObject storeCollider;
		public FsmFloat storeForce;
	}
}
