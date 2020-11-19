using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatInterpolate : FsmStateAction
	{
		public InterpolationType mode;
		public FsmFloat fromFloat;
		public FsmFloat toFloat;
		public FsmFloat time;
		public FsmFloat storeResult;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
