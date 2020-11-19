using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGet : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmInt atIndex;
		public FsmVar result;
		public FsmEvent failureEvent;
	}
}
