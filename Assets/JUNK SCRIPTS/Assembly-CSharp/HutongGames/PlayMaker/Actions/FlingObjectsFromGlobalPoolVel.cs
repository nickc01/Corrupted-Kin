using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FlingObjectsFromGlobalPoolVel : RigidBody2dActionBase
	{
		public FsmGameObject gameObject;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmInt spawnMin;
		public FsmInt spawnMax;
		public FsmFloat speedMinX;
		public FsmFloat speedMaxX;
		public FsmFloat speedMinY;
		public FsmFloat speedMaxY;
		public FsmFloat originVariationX;
		public FsmFloat originVariationY;
	}
}
