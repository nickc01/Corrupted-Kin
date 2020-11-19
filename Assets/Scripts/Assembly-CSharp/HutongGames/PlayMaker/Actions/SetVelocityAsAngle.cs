using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetVelocityAsAngle : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat angle;
		public FsmFloat speed;
		public bool everyFrame;
	}
}
