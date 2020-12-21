using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimateVector3 : AnimateFsmAction
	{
		public FsmVector3 vectorVariable;
		public FsmAnimationCurve curveX;
		public AnimateFsmAction.Calculation calculationX;
		public FsmAnimationCurve curveY;
		public AnimateFsmAction.Calculation calculationY;
		public FsmAnimationCurve curveZ;
		public AnimateFsmAction.Calculation calculationZ;
	}
}
