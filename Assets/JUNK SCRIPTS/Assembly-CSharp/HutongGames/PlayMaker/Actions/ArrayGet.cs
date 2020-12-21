using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayGet : FsmStateAction
	{
		public FsmArray array;
		public FsmInt index;
		public FsmVar storeValue;
		public bool everyFrame;
		public FsmEvent indexOutOfRange;
	}
}
