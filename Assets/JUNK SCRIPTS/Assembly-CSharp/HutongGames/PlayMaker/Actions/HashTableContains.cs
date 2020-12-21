using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableContains : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString key;
		public FsmBool containsKey;
		public FsmEvent keyFoundEvent;
		public FsmEvent keyNotFoundEvent;
	}
}
