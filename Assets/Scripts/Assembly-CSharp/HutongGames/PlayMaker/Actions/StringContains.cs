using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringContains : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmString containsString;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
