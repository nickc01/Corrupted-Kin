using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetFsmVector3 : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmVector3 setValue;
		public bool everyFrame;
	}
}
