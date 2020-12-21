using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringChanged : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmEvent changedEvent;
		public FsmBool storeResult;
	}
}
