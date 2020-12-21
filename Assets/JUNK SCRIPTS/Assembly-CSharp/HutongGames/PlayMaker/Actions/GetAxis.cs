using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAxis : FsmStateAction
	{
		public FsmString axisName;
		public FsmFloat multiplier;
		public FsmFloat store;
		public bool everyFrame;
	}
}
