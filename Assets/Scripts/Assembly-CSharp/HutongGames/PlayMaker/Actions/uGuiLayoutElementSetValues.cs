using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiLayoutElementSetValues : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat minWidth;
		public FsmFloat minHeight;
		public FsmFloat preferredWidth;
		public FsmFloat preferredHeight;
		public FsmFloat flexibleWidth;
		public FsmFloat flexibleHeight;
		public bool everyFrame;
	}
}
