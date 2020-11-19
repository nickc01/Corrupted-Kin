using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectIsNull : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmEvent isNull;
		public FsmEvent isNotNull;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
