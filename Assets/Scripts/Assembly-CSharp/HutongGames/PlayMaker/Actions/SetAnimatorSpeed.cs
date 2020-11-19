using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorSpeed : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat speed;
		public bool everyFrame;
	}
}
