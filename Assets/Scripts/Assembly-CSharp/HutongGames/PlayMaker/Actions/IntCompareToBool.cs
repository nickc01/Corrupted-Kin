using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntCompareToBool : FsmStateAction
	{
		public FsmInt integer1;
		public FsmInt integer2;
		public FsmBool equalBool;
		public FsmBool lessThanBool;
		public FsmBool greaterThanBool;
		public bool everyFrame;
	}
}
