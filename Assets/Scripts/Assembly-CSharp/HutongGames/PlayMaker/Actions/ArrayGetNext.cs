using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayGetNext : FsmStateAction
	{
		public FsmArray array;
		public FsmInt startIndex;
		public FsmInt endIndex;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
		public FsmVar result;
		public FsmInt currentIndex;
	}
}
