using HutongGames.PlayMaker;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	public class GetInControlDeviceInputAxisVector : FsmStateAction
	{
		public enum AxisPlane
		{
			XZ = 0,
			XY = 1,
			YZ = 2,
		}

		public FsmInt deviceIndex;
		public InputControlType horizontalAxis;
		public InputControlType verticalAxis;
		public FsmFloat multiplier;
		public AxisPlane mapToPlane;
		public FsmGameObject relativeTo;
		public FsmVector3 storeVector;
		public FsmFloat storeMagnitude;
	}
}
