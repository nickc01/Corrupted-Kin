using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CurveRect : CurveFsmAction
	{
		public FsmRect rectVariable;
		public FsmRect fromValue;
		public FsmRect toValue;
		public FsmAnimationCurve curveX;
		public CurveFsmAction.Calculation calculationX;
		public FsmAnimationCurve curveY;
		public CurveFsmAction.Calculation calculationY;
		public FsmAnimationCurve curveW;
		public CurveFsmAction.Calculation calculationW;
		public FsmAnimationCurve curveH;
		public CurveFsmAction.Calculation calculationH;
	}
}
