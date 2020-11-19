using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringCompare : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmString compareTo;
		public FsmEvent equalEvent;
		public FsmEvent notEqualEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
