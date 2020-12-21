using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectCompare : FsmStateAction
	{
		public FsmOwnerDefault gameObjectVariable;
		public FsmGameObject compareTo;
		public FsmEvent equalEvent;
		public FsmEvent notEqualEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
