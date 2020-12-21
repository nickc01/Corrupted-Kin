using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetChild : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString childName;
		public FsmString withTag;
		public FsmGameObject storeResult;
	}
}
