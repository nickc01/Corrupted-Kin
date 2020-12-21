using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEventByName : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public FsmString sendEvent;
		public FsmFloat delay;
		public bool everyFrame;
	}
}
