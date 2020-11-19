using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CurveVector3 : CurveFsmAction
	{
		public FsmVector3 vectorVariable;
		public FsmVector3 fromValue;
		public FsmVector3 toValue;
		public FsmAnimationCurve curveX;
		public CurveFsmAction.Calculation calculationX;
		public FsmAnimationCurve curveY;
		public CurveFsmAction.Calculation calculationY;
		public FsmAnimationCurve curveZ;
		public CurveFsmAction.Calculation calculationZ;
	}
}
