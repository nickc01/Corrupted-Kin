using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorFloat : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmString parameter;
		public FsmFloat Value;
		public FsmFloat dampTime;
	}
}
