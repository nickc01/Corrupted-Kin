using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmObject : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmObject setValue;
		public bool everyFrame;
	}
}
