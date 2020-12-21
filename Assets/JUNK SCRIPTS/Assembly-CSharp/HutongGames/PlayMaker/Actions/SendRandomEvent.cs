using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendRandomEvent : FsmStateAction
	{
		public FsmEvent[] events;
		public FsmFloat[] weights;
		public FsmFloat delay;
	}
}
