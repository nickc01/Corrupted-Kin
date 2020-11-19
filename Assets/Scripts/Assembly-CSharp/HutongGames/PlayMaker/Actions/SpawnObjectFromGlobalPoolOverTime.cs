using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SpawnObjectFromGlobalPoolOverTime : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmVector3 rotation;
		public FsmFloat frequency;
	}
}
