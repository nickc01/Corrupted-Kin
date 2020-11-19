using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimateColor : AnimateFsmAction
	{
		public FsmColor colorVariable;
		public FsmAnimationCurve curveR;
		public AnimateFsmAction.Calculation calculationR;
		public FsmAnimationCurve curveG;
		public AnimateFsmAction.Calculation calculationG;
		public FsmAnimationCurve curveB;
		public AnimateFsmAction.Calculation calculationB;
		public FsmAnimationCurve curveA;
		public AnimateFsmAction.Calculation calculationA;
	}
}
