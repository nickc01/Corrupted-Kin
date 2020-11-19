using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FaceDirection : RigidBody2dActionBase
	{
		public FsmOwnerDefault gameObject;
		public FsmBool spriteFacesRight;
		public bool playNewAnimation;
		public FsmString newAnimationClip;
		public bool everyFrame;
		public bool pauseBetweenTurns;
		public FsmFloat pauseTime;
	}
}
