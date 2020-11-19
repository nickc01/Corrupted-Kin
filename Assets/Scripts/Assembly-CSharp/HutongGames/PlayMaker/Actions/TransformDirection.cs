using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TransformDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 localDirection;
		public FsmVector3 storeResult;
		public bool everyFrame;
	}
}
