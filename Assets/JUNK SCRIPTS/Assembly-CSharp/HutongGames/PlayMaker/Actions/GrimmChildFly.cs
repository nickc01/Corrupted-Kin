using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GrimmChildFly : FsmStateAction
	{
		public FsmGameObject objectA;
		public FsmGameObject objectB;
		public FsmBool spriteFacesRight;
		public bool playNewAnimation;
		public FsmString newAnimationClip;
		public bool resetFrame;
		public FsmFloat fastAnimSpeed;
		public FsmString fastAnimationClip;
		public FsmString normalAnimationClip;
		public FsmFloat pauseBetweenAnimChange;
		public bool flyingFast;
	}
}
