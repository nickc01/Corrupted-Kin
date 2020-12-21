using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimatorCrossFade : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString stateName;
		public FsmFloat transitionDuration;
		public FsmInt layer;
		public FsmFloat normalizedTime;
	}
}
