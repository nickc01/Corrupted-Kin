using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DistanceWalk : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat distance;
		public FsmFloat speed;
		public FsmFloat range;
		public bool changeAnimation;
		public bool spriteFacesRight;
		public FsmString forwardAnimation;
		public FsmString backAnimation;
	}
}
