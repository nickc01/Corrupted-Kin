using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimationWeight : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public FsmFloat weight;
		public bool everyFrame;
	}
}
