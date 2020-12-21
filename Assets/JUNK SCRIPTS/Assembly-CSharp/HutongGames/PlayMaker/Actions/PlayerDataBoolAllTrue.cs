using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayerDataBoolAllTrue : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString[] stringVariables;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
