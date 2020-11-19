using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmArrayItem : BaseFsmVariableIndexAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmInt index;
		public FsmVar value;
		public bool everyFrame;
	}
}
