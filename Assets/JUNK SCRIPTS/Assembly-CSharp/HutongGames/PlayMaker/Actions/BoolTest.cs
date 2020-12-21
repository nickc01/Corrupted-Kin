using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoolTest : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmEvent isTrue;
		public FsmEvent isFalse;
		public bool everyFrame;
	}
}
