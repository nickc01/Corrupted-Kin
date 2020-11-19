using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatSwitch : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat[] lessThan;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
