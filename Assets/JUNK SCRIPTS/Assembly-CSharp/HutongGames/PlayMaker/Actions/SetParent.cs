using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetParent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject parent;
		public FsmBool resetLocalPosition;
		public FsmBool resetLocalRotation;
	}
}
