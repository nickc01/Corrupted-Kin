using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiCanvasEnableRaycastFilter : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool enableRaycasting;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
