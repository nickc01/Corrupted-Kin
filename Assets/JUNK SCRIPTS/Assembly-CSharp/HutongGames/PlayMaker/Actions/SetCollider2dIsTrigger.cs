using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetCollider2dIsTrigger : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isTrigger;
		public bool setAllColliders;
	}
}
