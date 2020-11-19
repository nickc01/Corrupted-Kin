using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertBoolToString : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmString stringVariable;
		public FsmString falseString;
		public FsmString trueString;
		public bool everyFrame;
	}
}
