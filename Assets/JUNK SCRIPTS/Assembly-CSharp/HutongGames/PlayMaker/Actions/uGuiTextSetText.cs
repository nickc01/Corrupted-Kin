using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiTextSetText : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString text;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
