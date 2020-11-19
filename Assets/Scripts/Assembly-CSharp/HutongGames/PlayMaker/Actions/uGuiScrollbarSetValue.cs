using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiScrollbarSetValue : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat value;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
