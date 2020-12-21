using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CurveFloat : CurveFsmAction
	{
		public FsmFloat floatVariable;
		public FsmFloat fromValue;
		public FsmFloat toValue;
		public FsmAnimationCurve animCurve;
		public CurveFsmAction.Calculation calculation;
	}
}
