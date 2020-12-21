using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableAdd : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString key;
		public FsmVar variable;
		public FsmEvent successEvent;
		public FsmEvent keyExistsAlreadyEvent;
	}
}
