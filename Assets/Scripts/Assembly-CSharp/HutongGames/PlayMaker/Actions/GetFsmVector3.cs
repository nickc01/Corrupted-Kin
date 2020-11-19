using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetFsmVector3 : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmVector3 storeValue;
		public bool everyFrame;
	}
}
