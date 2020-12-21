using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendTrigger2DEventByName : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public PlayMakerUnity2d.Trigger2DType trigger;
		public FsmString collideTag;
		public FsmInt collideLayer;
		public FsmString sendEvent;
		public FsmGameObject storeCollider;
	}
}
