using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectCompareTag : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmString tag;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
