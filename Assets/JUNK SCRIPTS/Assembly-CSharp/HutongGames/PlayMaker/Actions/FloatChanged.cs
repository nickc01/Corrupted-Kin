using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatChanged : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmEvent changedEvent;
		public FsmBool storeResult;
	}
}
