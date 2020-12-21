using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ChaseObjectGround : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speedMax;
		public FsmFloat acceleration;
		public bool animateTurnAndRun;
		public FsmString runAnimation;
		public FsmString turnAnimation;
		public FsmFloat turnRange;
	}
}
