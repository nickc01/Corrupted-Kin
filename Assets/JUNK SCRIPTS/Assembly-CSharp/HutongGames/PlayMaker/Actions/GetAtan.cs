using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAtan : FsmStateAction
	{
		public FsmFloat Value;
		public FsmFloat angle;
		public FsmBool RadToDeg;
		public bool everyFrame;
	}
}
