using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimatorPlay : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString stateName;
		public FsmInt layer;
		public FsmFloat normalizedTime;
		public bool everyFrame;
	}
}
