using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableGet : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString key;
		public FsmVar result;
		public FsmEvent KeyFoundEvent;
		public FsmEvent KeyNotFoundEvent;
	}
}
