using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dPlayAnimationWithEvents : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString clipName;
		public FsmEvent animationTriggerEvent;
		public FsmEvent animationCompleteEvent;
	}
}
