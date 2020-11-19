using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmInt : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmInt setValue;
		public bool everyFrame;
	}
}
