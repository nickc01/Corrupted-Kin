using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableIsEmpty : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmBool isEmpty;
		public FsmEvent isEmptyEvent;
		public FsmEvent isNotEmptyEvent;
	}
}
