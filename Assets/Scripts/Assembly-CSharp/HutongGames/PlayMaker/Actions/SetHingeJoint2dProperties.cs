using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetHingeJoint2dProperties : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool useLimits;
		public FsmFloat min;
		public FsmFloat max;
		public FsmBool useMotor;
		public FsmFloat motorSpeed;
		public FsmFloat maxMotorTorque;
		public bool everyFrame;
	}
}
