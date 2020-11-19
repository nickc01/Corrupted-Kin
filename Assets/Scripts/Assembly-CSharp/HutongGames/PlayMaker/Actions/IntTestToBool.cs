using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntTestToBool : FsmStateAction
	{
		public FsmInt int1;
		public FsmInt int2;
		public FsmBool equalBool;
		public FsmBool lessThanBool;
		public FsmBool greaterThanBool;
		public bool everyFrame;
	}
}
