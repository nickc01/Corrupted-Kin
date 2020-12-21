using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimationSpeed : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public FsmFloat speed;
		public bool everyFrame;
	}
}
