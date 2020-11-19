using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RandomFloatV2 : FsmStateAction
	{
		public FsmFloat min;
		public FsmFloat max;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
