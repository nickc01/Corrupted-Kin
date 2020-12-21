using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetTan : FsmStateAction
	{
		public FsmFloat angle;
		public FsmBool DegToRad;
		public FsmFloat result;
		public bool everyFrame;
	}
}
