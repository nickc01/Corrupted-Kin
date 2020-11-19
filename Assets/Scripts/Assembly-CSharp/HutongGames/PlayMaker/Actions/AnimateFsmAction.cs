using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimateFsmAction : FsmStateAction
	{
		public enum Calculation
		{
			None = 0,
			SetValue = 1,
			AddToValue = 2,
			SubtractFromValue = 3,
			SubtractValueFromCurve = 4,
			MultiplyValue = 5,
			DivideValue = 6,
			DivideCurveByValue = 7,
		}

		public FsmFloat time;
		public FsmFloat speed;
		public FsmFloat delay;
		public FsmBool ignoreCurveOffset;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
