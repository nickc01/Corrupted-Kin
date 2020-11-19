using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetCircleColliderRadius : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat radius;
		public bool everyFrame;
	}
}
