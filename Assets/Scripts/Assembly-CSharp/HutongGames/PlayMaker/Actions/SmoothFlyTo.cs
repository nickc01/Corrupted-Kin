using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothFlyTo : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat distance;
		public FsmFloat speedMax;
		public FsmFloat accelerationForce;
		public FsmFloat targetRadius;
		public FsmFloat deceleration;
		public FsmVector3 offset;
	}
}
