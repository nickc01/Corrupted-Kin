using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetStringLeft : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmInt charCount;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
