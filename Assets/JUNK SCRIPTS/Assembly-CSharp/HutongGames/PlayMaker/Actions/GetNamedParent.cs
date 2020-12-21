using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNamedParent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString parentName;
		public FsmString withTag;
		public FsmGameObject storeResult;
	}
}
