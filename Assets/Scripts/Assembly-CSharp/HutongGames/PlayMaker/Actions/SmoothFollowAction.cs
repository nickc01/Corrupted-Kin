using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothFollowAction : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmFloat distance;
		public FsmFloat height;
		public FsmFloat heightDamping;
		public FsmFloat rotationDamping;
	}
}
