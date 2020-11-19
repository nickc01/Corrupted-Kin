using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAxisVector : FsmStateAction
	{
		public enum AxisPlane
		{
			XZ = 0,
			XY = 1,
			YZ = 2,
		}

		public FsmString horizontalAxis;
		public FsmString verticalAxis;
		public FsmFloat multiplier;
		public AxisPlane mapToPlane;
		public FsmGameObject relativeTo;
		public FsmVector3 storeVector;
		public FsmFloat storeMagnitude;
	}
}
