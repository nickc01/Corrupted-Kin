using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ChaseObjectV2 : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speedMax;
		public FsmFloat accelerationForce;
		public FsmFloat offsetX;
		public FsmFloat offsetY;
	}
}
