using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ChaseObjectVertical : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speedMax;
		public FsmFloat acceleration;
	}
}
