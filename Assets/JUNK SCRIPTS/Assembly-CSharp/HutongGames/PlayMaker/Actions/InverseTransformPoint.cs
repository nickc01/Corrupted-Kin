using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class InverseTransformPoint : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 worldPosition;
		public FsmVector3 storeResult;
		public bool everyFrame;
	}
}
