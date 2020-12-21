using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SpawnObjectFromGlobalPoolOverTimeV2 : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmVector3 rotation;
		public FsmFloat frequency;
		public FsmFloat scaleMin;
		public FsmFloat scaleMax;
	}
}
