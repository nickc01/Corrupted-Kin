using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayCompare : FsmStateAction
	{
		public FsmArray array1;
		public FsmArray array2;
		public FsmEvent SequenceEqual;
		public FsmEvent SequenceNotEqual;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
