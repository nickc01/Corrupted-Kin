using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Collision2dEvent : FsmStateAction
	{
		public Collision2DType collision;
		public FsmString collideTag;
		public FsmEvent sendEvent;
		public FsmGameObject storeCollider;
		public FsmFloat storeForce;
	}
}
