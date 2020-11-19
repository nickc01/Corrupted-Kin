using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimationTime : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public FsmFloat time;
		public bool normalized;
		public bool everyFrame;
	}
}
