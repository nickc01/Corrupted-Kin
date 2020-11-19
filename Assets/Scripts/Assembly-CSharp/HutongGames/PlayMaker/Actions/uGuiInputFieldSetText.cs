using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldSetText : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString text;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
