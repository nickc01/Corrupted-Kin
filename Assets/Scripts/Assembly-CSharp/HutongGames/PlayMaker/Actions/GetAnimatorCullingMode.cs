using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCullingMode : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool alwaysAnimate;
		public FsmEvent alwaysAnimateEvent;
		public FsmEvent basedOnRenderersEvent;
	}
}
