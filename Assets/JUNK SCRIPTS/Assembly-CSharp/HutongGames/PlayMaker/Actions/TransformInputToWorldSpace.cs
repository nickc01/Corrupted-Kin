using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TransformInputToWorldSpace : FsmStateAction
	{
		public enum AxisPlane
		{
			XZ = 0,
			XY = 1,
			YZ = 2,
		}

		public FsmFloat horizontalInput;
		public FsmFloat verticalInput;
		public FsmFloat multiplier;
		public AxisPlane mapToPlane;
		public FsmGameObject relativeTo;
		public FsmVector3 storeVector;
		public FsmFloat storeMagnitude;
	}
}
