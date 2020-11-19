using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListContains : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmVar variable;
		public FsmBool isContained;
		public FsmEvent isContainedEvent;
		public FsmEvent isNotContainedEvent;
	}
}
