using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TransformPoint : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 localPosition;
		public FsmVector3 storeResult;
		public bool everyFrame;
	}
}
