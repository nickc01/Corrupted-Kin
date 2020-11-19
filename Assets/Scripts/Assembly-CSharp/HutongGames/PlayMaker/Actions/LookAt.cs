using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LookAt : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmVector3 targetPosition;
		public FsmVector3 upVector;
		public FsmBool keepVertical;
		public FsmBool debug;
		public FsmColor debugLineColor;
		public bool everyFrame;
	}
}
