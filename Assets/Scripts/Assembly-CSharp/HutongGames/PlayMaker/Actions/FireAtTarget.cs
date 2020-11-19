using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FireAtTarget : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat speed;
		public FsmVector3 position;
		public FsmFloat spread;
		public bool everyFrame;
	}
}
