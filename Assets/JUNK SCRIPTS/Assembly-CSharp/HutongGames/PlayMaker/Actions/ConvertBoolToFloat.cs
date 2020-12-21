using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertBoolToFloat : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmFloat floatVariable;
		public FsmFloat falseValue;
		public FsmFloat trueValue;
		public bool everyFrame;
	}
}
