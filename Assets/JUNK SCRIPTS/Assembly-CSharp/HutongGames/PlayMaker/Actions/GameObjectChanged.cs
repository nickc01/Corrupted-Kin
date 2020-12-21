using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectChanged : FsmStateAction
	{
		public FsmGameObject gameObjectVariable;
		public FsmEvent changedEvent;
		public FsmBool storeResult;
	}
}
