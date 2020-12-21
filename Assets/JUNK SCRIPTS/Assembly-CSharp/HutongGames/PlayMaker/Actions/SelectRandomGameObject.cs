using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SelectRandomGameObject : FsmStateAction
	{
		public FsmGameObject[] gameObjects;
		public FsmFloat[] weights;
		public FsmGameObject storeGameObject;
	}
}
