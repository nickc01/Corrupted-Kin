using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ChaseObject : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speedMax;
		public FsmFloat acceleration;
		public FsmFloat targetSpread;
		public FsmFloat spreadResetTimeMin;
		public FsmFloat spreadResetTimeMax;
	}
}
