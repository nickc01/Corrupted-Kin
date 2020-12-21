using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddForce2dAsAngle : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 atPosition;
		public FsmFloat angle;
		public FsmFloat speed;
		public FsmFloat maxSpeed;
		public FsmFloat maxSpeedX;
		public FsmFloat maxSpeedY;
		public bool everyFrame;
	}
}
