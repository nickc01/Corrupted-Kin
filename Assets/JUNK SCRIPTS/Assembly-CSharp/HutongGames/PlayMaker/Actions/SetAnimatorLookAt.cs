using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorLookAt : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmVector3 targetPosition;
		public FsmFloat weight;
		public FsmFloat bodyWeight;
		public FsmFloat headWeight;
		public FsmFloat eyesWeight;
		public FsmFloat clampWeight;
		public bool everyFrame;
	}
}
