using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetDeviceRoll : FsmStateAction
	{
		public enum BaseOrientation
		{
			Portrait = 0,
			LandscapeLeft = 1,
			LandscapeRight = 2,
		}

		public BaseOrientation baseOrientation;
		public FsmFloat storeAngle;
		public FsmFloat limitAngle;
		public FsmFloat smoothing;
		public bool everyFrame;
	}
}
