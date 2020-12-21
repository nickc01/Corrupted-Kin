using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class InverseTransformDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 worldDirection;
		public FsmVector3 storeResult;
		public bool everyFrame;
	}
}
