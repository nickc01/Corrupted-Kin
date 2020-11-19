using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAngleToTarget : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmVector3 targetPosition;
		public FsmBool ignoreHeight;
		public FsmFloat storeAngle;
		public bool everyFrame;
	}
}
