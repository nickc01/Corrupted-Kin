using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorIsHuman : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isHuman;
		public FsmEvent isHumanEvent;
		public FsmEvent isGenericEvent;
	}
}
