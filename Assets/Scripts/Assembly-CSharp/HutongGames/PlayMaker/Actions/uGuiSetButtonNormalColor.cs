using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiSetButtonNormalColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor normalColor;
		public bool resetOnExit;
		public new FsmBool enabled;
		public bool everyFrame;
	}
}
