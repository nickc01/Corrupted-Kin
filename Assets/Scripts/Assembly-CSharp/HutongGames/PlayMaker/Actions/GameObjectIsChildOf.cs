using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectIsChildOf : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject isChildOf;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
	}
}
