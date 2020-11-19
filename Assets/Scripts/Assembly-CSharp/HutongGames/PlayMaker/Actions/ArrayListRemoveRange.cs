using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListRemoveRange : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmInt index;
		public FsmInt count;
		public FsmEvent failureEvent;
	}
}
