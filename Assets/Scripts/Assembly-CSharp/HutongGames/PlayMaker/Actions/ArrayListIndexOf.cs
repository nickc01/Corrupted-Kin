using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListIndexOf : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmInt startIndex;
		public FsmInt count;
		public FsmVar variable;
		public FsmInt indexOf;
		public FsmEvent itemFound;
		public FsmEvent itemNotFound;
		public FsmEvent failureEvent;
	}
}
