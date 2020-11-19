using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableContainsKey : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString key;
		public FsmBool containsKey;
		public FsmEvent keyFoundEvent;
		public FsmEvent keyNotFoundEvent;
	}
}
