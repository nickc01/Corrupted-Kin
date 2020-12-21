using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Collision2dEventLayer : FsmStateAction
	{
		public PlayMakerUnity2d.Collision2DType collision;
		public FsmString collideTag;
		public FsmInt collideLayer;
		public FsmEvent sendEvent;
		public FsmGameObject storeCollider;
		public FsmFloat storeForce;
	}
}
