using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEventByNameV2 : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public FsmString sendEvent;
		public FsmFloat delay;
		public bool everyFrame;
	}
}
