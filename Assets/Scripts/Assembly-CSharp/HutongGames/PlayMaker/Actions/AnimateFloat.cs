using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimateFloat : FsmStateAction
	{
		public FsmAnimationCurve animCurve;
		public FsmFloat floatVariable;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
