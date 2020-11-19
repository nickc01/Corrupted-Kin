using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetRandom : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmVar randomItem;
		public FsmInt randomIndex;
		public FsmEvent failureEvent;
	}
}
