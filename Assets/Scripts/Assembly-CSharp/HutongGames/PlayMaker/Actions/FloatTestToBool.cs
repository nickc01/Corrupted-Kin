using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatTestToBool : FsmStateAction
	{
		public FsmFloat float1;
		public FsmFloat float2;
		public FsmFloat tolerance;
		public FsmBool equalBool;
		public FsmBool lessThanBool;
		public FsmBool greaterThanBool;
		public bool everyFrame;
	}
}
