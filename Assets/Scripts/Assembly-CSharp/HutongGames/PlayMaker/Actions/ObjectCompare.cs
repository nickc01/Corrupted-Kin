using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ObjectCompare : FsmStateAction
	{
		public FsmObject objectVariable;
		public FsmObject compareTo;
		public FsmEvent equalEvent;
		public FsmEvent notEqualEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
