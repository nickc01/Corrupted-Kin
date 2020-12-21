using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class EaseFsmAction : FsmStateAction
	{
		public enum EaseType
		{
			easeInQuad = 0,
			easeOutQuad = 1,
			easeInOutQuad = 2,
			easeInCubic = 3,
			easeOutCubic = 4,
			easeInOutCubic = 5,
			easeInQuart = 6,
			easeOutQuart = 7,
			easeInOutQuart = 8,
			easeInQuint = 9,
			easeOutQuint = 10,
			easeInOutQuint = 11,
			easeInSine = 12,
			easeOutSine = 13,
			easeInOutSine = 14,
			easeInExpo = 15,
			easeOutExpo = 16,
			easeInOutExpo = 17,
			easeInCirc = 18,
			easeOutCirc = 19,
			easeInOutCirc = 20,
			linear = 21,
			spring = 22,
			bounce = 23,
			easeInBack = 24,
			easeOutBack = 25,
			easeInOutBack = 26,
			elastic = 27,
			punch = 28,
		}

		public FsmFloat time;
		public FsmFloat speed;
		public FsmFloat delay;
		public EaseType easeType;
		public FsmBool reverse;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
