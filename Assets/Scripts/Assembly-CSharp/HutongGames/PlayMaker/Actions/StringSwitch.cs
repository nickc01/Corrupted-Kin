using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringSwitch : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmString[] compareTo;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
