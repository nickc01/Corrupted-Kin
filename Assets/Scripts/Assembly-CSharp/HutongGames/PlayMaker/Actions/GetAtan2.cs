using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAtan2 : FsmStateAction
	{
		public FsmFloat xValue;
		public FsmFloat yValue;
		public FsmFloat angle;
		public FsmBool RadToDeg;
		public bool everyFrame;
	}
}
