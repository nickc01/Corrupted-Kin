using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorPlayBackSpeed : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat playBackSpeed;
		public bool everyFrame;
	}
}
