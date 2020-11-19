using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertBoolToInt : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmInt intVariable;
		public FsmInt falseValue;
		public FsmInt trueValue;
		public bool everyFrame;
	}
}
