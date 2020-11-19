using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ForwardEvent : FsmStateAction
	{
		public FsmEventTarget forwardTo;
		public FsmEvent[] eventsToForward;
		public bool eatEvents;
	}
}
