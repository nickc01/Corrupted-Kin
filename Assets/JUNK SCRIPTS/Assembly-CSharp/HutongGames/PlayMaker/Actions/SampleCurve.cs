using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SampleCurve : FsmStateAction
	{
		public FsmAnimationCurve curve;
		public FsmFloat sampleAt;
		public FsmFloat storeValue;
		public bool everyFrame;
	}
}
