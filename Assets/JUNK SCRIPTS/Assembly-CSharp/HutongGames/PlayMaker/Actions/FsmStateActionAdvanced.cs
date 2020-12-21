using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmStateActionAdvanced : FsmStateAction
	{
		public enum FrameUpdateSelector
		{
			OnUpdate = 0,
			OnLateUpdate = 1,
			OnFixedUpdate = 2,
		}

		public bool everyFrame;
		public FrameUpdateSelector updateType;
	}
}
