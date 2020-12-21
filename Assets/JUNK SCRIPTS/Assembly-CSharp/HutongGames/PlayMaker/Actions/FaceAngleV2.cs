using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FaceAngleV2 : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat angleOffset;
		public FsmBool worldSpace;
		public bool everyFrame;
	}
}
