using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetDeviceAcceleration : FsmStateAction
	{
		public FsmVector3 storeVector;
		public FsmFloat storeX;
		public FsmFloat storeY;
		public FsmFloat storeZ;
		public FsmFloat multiplier;
		public bool everyFrame;
	}
}
