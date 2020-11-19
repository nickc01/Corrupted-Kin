using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FindChild : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString childName;
		public FsmGameObject storeResult;
	}
}
