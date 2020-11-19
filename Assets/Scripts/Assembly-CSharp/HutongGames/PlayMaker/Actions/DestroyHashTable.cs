using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DestroyHashTable : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmEvent successEvent;
		public FsmEvent notFoundEvent;
	}
}
