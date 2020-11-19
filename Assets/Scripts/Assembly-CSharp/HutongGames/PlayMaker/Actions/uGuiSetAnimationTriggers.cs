using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiSetAnimationTriggers : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString normalTrigger;
		public FsmString highlightedTrigger;
		public FsmString pressedTrigger;
		public FsmString disabledTrigger;
		public FsmBool resetOnExit;
	}
}
