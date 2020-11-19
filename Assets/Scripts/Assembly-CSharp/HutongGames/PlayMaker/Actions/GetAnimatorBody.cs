using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorBody : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 bodyPosition;
		public FsmQuaternion bodyRotation;
		public FsmGameObject bodyGameObject;
	}
}
