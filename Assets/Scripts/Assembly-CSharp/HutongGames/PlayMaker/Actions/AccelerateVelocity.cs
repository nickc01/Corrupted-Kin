using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AccelerateVelocity : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat xAccel;
		public FsmFloat yAccel;
		public FsmFloat xMaxSpeed;
		public FsmFloat yMaxSpeed;
	}
}
