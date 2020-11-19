using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorApplyRootMotion : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool rootMotionApplied;
		public FsmEvent rootMotionIsAppliedEvent;
		public FsmEvent rootMotionIsNotAppliedEvent;
	}
}
