using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CurveFsmAction : FsmStateAction
	{
		public enum Calculation
		{
			None = 0,
			AddToValue = 1,
			SubtractFromValue = 2,
			SubtractValueFromCurve = 3,
			MultiplyValue = 4,
			DivideValue = 5,
			DivideCurveByValue = 6,
		}

		public FsmFloat time;
		public FsmFloat speed;
		public FsmFloat delay;
		public FsmBool ignoreCurveOffset;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
