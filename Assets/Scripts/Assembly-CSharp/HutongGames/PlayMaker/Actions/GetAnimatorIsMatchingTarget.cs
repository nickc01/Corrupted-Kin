using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorIsMatchingTarget : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isMatchingActive;
		public FsmEvent matchingActivatedEvent;
		public FsmEvent matchingDeactivedEvent;
	}
}
