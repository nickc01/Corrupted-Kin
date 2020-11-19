using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorIsLayerInTransition : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public FsmBool isInTransition;
		public FsmEvent isInTransitionEvent;
		public FsmEvent isNotInTransitionEvent;
	}
}
