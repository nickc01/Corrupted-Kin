using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmEnum : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmEnum setValue;
		public bool everyFrame;
	}
}
