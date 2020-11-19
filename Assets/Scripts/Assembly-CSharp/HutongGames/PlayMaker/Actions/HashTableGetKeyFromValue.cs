using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableGetKeyFromValue : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmVar theValue;
		public FsmString result;
		public FsmEvent KeyFoundEvent;
		public FsmEvent KeyNotFoundEvent;
	}
}
