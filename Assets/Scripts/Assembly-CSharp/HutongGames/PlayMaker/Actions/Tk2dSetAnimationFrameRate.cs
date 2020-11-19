using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dSetAnimationFrameRate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat framePerSeconds;
		public bool everyFrame;
	}
}
