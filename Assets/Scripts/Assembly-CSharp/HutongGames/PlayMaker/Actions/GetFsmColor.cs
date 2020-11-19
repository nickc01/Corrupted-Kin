using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetFsmColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmColor storeValue;
		public bool everyFrame;
	}
}
