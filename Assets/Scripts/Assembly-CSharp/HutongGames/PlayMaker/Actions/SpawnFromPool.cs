using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SpawnFromPool : RigidBody2dActionBase
	{
		public FsmGameObject pool;
		public FsmVector3 adjustPosition;
		public FsmInt spawnMin;
		public FsmInt spawnMax;
		public FsmFloat speedMin;
		public FsmFloat speedMax;
		public FsmFloat angleMin;
		public FsmFloat angleMax;
	}
}
