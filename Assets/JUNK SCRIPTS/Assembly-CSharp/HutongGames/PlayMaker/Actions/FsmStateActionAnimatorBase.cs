using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmStateActionAnimatorBase : FsmStateAction
	{
		public enum AnimatorFrameUpdateSelector
		{
			OnUpdate = 0,
			OnAnimatorMove = 1,
			OnAnimatorIK = 2,
		}

		public bool everyFrame;
		public AnimatorFrameUpdateSelector everyFrameOption;
	}
}
