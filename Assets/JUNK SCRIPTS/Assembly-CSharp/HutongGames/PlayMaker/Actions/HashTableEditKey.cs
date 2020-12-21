using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableEditKey : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString key;
		public FsmString newKey;
		public FsmEvent keyNotFoundEvent;
		public FsmEvent newKeyExistsAlreadyEvent;
	}
}
