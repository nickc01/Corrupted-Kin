using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntSwitch : FsmStateAction
	{
		public FsmInt intVariable;
		public FsmInt[] compareTo;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
