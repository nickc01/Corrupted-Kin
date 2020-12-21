using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetPrevious : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmBool reset;
		public FsmInt startIndex;
		public FsmInt endIndex;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
		public FsmEvent failureEvent;
		public FsmInt currentIndex;
		public FsmVar result;
	}
}
