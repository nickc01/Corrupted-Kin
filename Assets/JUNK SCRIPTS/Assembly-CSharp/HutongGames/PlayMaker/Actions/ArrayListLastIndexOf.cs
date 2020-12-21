using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListLastIndexOf : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmInt startIndex;
		public FsmInt count;
		public FsmVar variable;
		public FsmInt lastIndexOf;
		public FsmEvent itemFound;
		public FsmEvent itemNotFound;
		public FsmEvent failureEvent;
	}
}
