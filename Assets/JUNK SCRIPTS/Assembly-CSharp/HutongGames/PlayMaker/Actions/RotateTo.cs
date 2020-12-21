using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RotateTo : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat targetAngle;
		public FsmFloat speed;
	}
}
