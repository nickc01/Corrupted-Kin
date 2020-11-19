using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEvent : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public FsmEvent sendEvent;
		public FsmFloat delay;
		public bool everyFrame;
	}
}
