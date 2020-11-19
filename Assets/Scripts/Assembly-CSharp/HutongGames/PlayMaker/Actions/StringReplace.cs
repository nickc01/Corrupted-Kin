using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringReplace : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmString replace;
		public FsmString with;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
