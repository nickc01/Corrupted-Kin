using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DestroyArrayList : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmEvent successEvent;
		public FsmEvent notFoundEvent;
	}
}
