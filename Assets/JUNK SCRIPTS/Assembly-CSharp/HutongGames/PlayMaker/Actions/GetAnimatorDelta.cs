using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorDelta : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 deltaPosition;
		public FsmQuaternion deltaRotation;
	}
}
