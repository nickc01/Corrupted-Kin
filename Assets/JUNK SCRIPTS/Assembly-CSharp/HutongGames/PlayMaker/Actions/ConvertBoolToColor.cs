using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertBoolToColor : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmColor colorVariable;
		public FsmColor falseColor;
		public FsmColor trueColor;
		public bool everyFrame;
	}
}
