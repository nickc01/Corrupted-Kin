using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetWheelJoint2dProperties : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool useMotor;
		public FsmFloat motorSpeed;
		public FsmFloat maxMotorTorque;
		public FsmFloat angle;
		public FsmFloat dampingRatio;
		public FsmFloat frequency;
		public bool everyFrame;
	}
}
