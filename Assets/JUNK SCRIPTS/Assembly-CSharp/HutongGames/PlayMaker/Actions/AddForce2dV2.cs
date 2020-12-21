using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddForce2dV2 : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 atPosition;
		public FsmVector2 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmVector3 vector3;
		public FsmFloat maxSpeed;
		public FsmFloat maxSpeedX;
		public FsmFloat maxSpeedY;
		public bool everyFrame;
	}
}
