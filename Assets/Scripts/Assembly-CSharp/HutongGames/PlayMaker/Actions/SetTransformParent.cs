using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTransformParent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject parent;
		public FsmBool worldPositionStays;
	}
}
