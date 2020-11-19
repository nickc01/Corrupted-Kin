using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DistanceFlyV2 : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat distance;
		public FsmFloat speedMax;
		public FsmFloat acceleration;
		public bool targetsHeight;
		public FsmFloat height;
		public FsmBool stayLeft;
		public FsmBool stayRight;
	}
}
