using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAngularVelocity2d : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat angularVelocity;
		public bool everyFrame;
	}
}
