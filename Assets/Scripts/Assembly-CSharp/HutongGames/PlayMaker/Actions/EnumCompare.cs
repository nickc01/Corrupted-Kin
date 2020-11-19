using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class EnumCompare : FsmStateAction
	{
		public FsmEnum enumVariable;
		public FsmEnum compareTo;
		public FsmEvent equalEvent;
		public FsmEvent notEqualEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
