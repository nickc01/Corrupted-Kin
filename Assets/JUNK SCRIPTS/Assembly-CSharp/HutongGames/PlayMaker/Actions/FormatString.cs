using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FormatString : FsmStateAction
	{
		public FsmString format;
		public FsmVar[] variables;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
