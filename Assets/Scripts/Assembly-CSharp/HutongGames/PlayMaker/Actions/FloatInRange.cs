using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatInRange : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat lowerValue;
		public FsmFloat upperValue;
		public FsmBool boolVariable;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public bool everyFrame;
	}
}
