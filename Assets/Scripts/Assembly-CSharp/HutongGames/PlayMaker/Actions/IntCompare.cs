using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntCompare : FsmStateAction
	{
		public FsmInt integer1;
		public FsmInt integer2;
		public FsmEvent equal;
		public FsmEvent lessThan;
		public FsmEvent greaterThan;
		public bool everyFrame;
	}
}
