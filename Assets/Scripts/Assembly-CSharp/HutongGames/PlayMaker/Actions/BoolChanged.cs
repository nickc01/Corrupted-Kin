using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoolChanged : FsmStateAction
	{
		public FsmBool boolVariable;
		public FsmEvent changedEvent;
		public FsmBool storeResult;
	}
}
