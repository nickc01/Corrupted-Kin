using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FlingObjectsFromGlobalPoolTime : RigidBody2dActionBase
	{
		public FsmGameObject gameObject;
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmFloat frequency;
		public FsmInt spawnMin;
		public FsmInt spawnMax;
		public FsmFloat speedMin;
		public FsmFloat speedMax;
		public FsmFloat angleMin;
		public FsmFloat angleMax;
		public FsmFloat originVariationX;
		public FsmFloat originVariationY;
	}
}
