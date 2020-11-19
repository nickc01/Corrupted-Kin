using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmRect : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmRect setValue;
		public bool everyFrame;
	}
}
