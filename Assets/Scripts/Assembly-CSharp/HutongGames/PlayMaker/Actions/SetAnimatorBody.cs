using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorBody : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmVector3 position;
		public FsmQuaternion rotation;
		public bool everyFrame;
	}
}
