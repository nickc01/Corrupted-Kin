using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetFsmArrayItem : BaseFsmVariableIndexAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmInt index;
		public FsmVar storeValue;
		public bool everyFrame;
	}
}
