using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Trigger2dEvent : FsmStateAction
	{
		public PlayMakerUnity2d.Trigger2DType trigger;
		public FsmString collideTag;
		public FsmString collideLayer;
		public FsmEvent sendEvent;
		public FsmGameObject storeCollider;
	}
}
