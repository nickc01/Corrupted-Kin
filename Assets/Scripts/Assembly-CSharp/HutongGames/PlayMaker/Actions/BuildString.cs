using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BuildString : FsmStateAction
	{
		public FsmString[] stringParts;
		public FsmString separator;
		public FsmBool addToEnd;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
