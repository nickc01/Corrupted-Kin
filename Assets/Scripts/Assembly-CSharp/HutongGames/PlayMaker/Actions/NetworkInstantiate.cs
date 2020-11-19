using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkInstantiate : FsmStateAction
	{
		public FsmGameObject prefab;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmVector3 rotation;
		public FsmGameObject storeObject;
		public FsmInt networkGroup;
	}
}
