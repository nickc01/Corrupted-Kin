using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetCosine : FsmStateAction
	{
		public FsmFloat angle;
		public FsmBool DegToRad;
		public FsmFloat result;
		public bool everyFrame;
	}
}
