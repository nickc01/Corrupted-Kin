using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class EnumSwitch : FsmStateAction
	{
		public FsmEnum enumVariable;
		public FsmEnum[] compareTo;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
