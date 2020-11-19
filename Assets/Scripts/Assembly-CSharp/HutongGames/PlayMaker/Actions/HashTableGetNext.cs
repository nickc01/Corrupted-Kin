using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableGetNext : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmBool reset;
		public FsmInt startIndex;
		public FsmInt endIndex;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
		public FsmEvent failureEvent;
		public FsmString key;
		public FsmVar result;
	}
}
