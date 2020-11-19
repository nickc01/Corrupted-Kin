using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GhostMovement : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat xPosMin;
		public FsmFloat xPosMax;
		public FsmFloat accel_x;
		public FsmFloat speedMax_x;
		public FsmFloat yPosMin;
		public FsmFloat yPosMax;
		public FsmFloat accel_y;
		public FsmFloat speedMax_y;
		public FsmInt direction_x;
		public FsmInt direction_y;
	}
}
