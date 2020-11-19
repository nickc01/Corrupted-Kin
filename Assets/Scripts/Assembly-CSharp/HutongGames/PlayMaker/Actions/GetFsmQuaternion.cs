using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetFsmQuaternion : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmQuaternion storeValue;
		public bool everyFrame;
	}
}
