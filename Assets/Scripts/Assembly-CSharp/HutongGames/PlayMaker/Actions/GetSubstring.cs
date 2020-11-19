using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetSubstring : FsmStateAction
	{
		public FsmString stringVariable;
		public FsmInt startIndex;
		public FsmInt length;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
