using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorRoot : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 rootPosition;
		public FsmQuaternion rootRotation;
		public FsmGameObject bodyGameObject;
	}
}
