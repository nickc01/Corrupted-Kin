using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetVelocity2dIfFalse : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmBool checkBool;
		public bool everyFrame;
	}
}
