using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorPivot : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat pivotWeight;
		public FsmVector3 pivotPosition;
	}
}
