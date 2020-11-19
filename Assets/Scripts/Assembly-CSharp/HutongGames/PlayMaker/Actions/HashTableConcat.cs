using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HashTableConcat : HashTableActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmOwnerDefault[] hashTableGameObjectTargets;
		public FsmString[] referenceTargets;
		public FsmBool overwriteExistingKey;
	}
}
