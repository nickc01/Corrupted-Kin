using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayResize : FsmStateAction
	{
		public FsmArray array;
		public FsmInt newSize;
		public FsmEvent sizeOutOfRangeEvent;
	}
}
