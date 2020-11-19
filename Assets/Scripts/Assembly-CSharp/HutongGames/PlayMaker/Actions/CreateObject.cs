using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CreateObject : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmVector3 rotation;
		public FsmGameObject storeObject;
		public FsmBool networkInstantiate;
		public FsmInt networkGroup;
	}
}
