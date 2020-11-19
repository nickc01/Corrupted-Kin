using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoolAnyTrue : FsmStateAction
	{
		public FsmBool[] boolVariables;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
