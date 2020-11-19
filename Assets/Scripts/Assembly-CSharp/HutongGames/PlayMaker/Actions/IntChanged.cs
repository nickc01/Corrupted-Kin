using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntChanged : FsmStateAction
	{
		public FsmInt intVariable;
		public FsmEvent changedEvent;
		public FsmBool storeResult;
	}
}
