using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListExists : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmBool doesExists;
		public FsmEvent doesExistsEvent;
		public FsmEvent doesNotExistsEvent;
	}
}
