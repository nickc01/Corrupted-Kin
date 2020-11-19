using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoolTestMulti : FsmStateAction
	{
		public FsmBool[] boolVariables;
		public FsmBool[] boolStates;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
