using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimateRect : AnimateFsmAction
	{
		public FsmRect rectVariable;
		public FsmAnimationCurve curveX;
		public AnimateFsmAction.Calculation calculationX;
		public FsmAnimationCurve curveY;
		public AnimateFsmAction.Calculation calculationY;
		public FsmAnimationCurve curveW;
		public AnimateFsmAction.Calculation calculationW;
		public FsmAnimationCurve curveH;
		public AnimateFsmAction.Calculation calculationH;
	}
}
