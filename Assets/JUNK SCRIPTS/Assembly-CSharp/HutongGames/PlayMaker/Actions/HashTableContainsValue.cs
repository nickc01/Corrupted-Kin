using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableContainsValue : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmVar variable;
		public FsmBool containsValue;
		public FsmEvent valueFoundEvent;
		public FsmEvent valueNotFoundEvent;
	}
}
