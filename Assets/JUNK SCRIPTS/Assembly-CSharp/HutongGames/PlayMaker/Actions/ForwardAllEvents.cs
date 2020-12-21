using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ForwardAllEvents : FsmStateAction
	{
		public FsmEventTarget forwardTo;
		public FsmEvent[] exceptThese;
		public bool eatEvents;
	}
}
