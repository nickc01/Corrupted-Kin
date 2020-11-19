using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ProjectileSquash : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat stretchFactor;
		public float stretchMinX;
		public float stretchMaxY;
		public FsmFloat scaleModifier;
		public bool everyFrame;
	}
}
