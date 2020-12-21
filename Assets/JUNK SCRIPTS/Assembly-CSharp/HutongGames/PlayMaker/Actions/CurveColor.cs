using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CurveColor : CurveFsmAction
	{
		public FsmColor colorVariable;
		public FsmColor fromValue;
		public FsmColor toValue;
		public FsmAnimationCurve curveR;
		public CurveFsmAction.Calculation calculationR;
		public FsmAnimationCurve curveG;
		public CurveFsmAction.Calculation calculationG;
		public FsmAnimationCurve curveB;
		public CurveFsmAction.Calculation calculationB;
		public FsmAnimationCurve curveA;
		public CurveFsmAction.Calculation calculationA;
	}
}
