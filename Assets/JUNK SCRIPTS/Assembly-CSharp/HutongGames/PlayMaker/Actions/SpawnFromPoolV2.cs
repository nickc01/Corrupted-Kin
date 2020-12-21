using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SpawnFromPoolV2 : RigidBody2dActionBase
	{
		public FsmGameObject pool;
		public FsmVector3 setPosition;
		public FsmInt spawnMin;
		public FsmInt spawnMax;
		public FsmFloat speedMin;
		public FsmFloat speedMax;
		public FsmFloat angleMin;
		public FsmFloat angleMax;
		public FsmString FSM;
		public FsmString FSMEvent;
	}
}
