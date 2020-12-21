using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IdleBuzz : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat waitMin;
		public FsmFloat waitMax;
		public FsmFloat speedMax;
		public FsmFloat accelerationMax;
		public FsmFloat roamingRange;
	}
}
