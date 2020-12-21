using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableAddMany : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString[] keys;
		public FsmVar[] variables;
		public FsmEvent successEvent;
		public FsmEvent keyExistsAlreadyEvent;
	}
}
