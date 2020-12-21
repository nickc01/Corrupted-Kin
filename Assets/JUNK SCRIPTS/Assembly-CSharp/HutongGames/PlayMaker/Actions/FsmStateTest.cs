using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmStateTest : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmString fsmName;
		public FsmString stateName;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
