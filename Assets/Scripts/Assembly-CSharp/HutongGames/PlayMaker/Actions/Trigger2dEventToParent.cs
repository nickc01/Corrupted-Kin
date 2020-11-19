using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Trigger2dEventToParent : FsmStateAction
	{
		public PlayMakerUnity2d.Trigger2DType trigger;
		public FsmString collideTag;
		public FsmInt collideLayer;
		public FsmEvent sendEvent;
		public FsmGameObject storeCollider;
	}
}
