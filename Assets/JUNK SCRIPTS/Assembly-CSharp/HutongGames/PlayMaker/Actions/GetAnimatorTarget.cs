using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorTarget : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 targetPosition;
		public FsmQuaternion targetRotation;
		public FsmGameObject targetGameObject;
	}
}
