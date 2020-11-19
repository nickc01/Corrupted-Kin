using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RunAway : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speedMax;
		public FsmFloat acceleration;
		public bool animateTurnAndRun;
		public FsmString runAnimation;
		public FsmString turnAnimation;
	}
}
