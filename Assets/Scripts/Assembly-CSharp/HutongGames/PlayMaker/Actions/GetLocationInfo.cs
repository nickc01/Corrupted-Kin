using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetLocationInfo : FsmStateAction
	{
		public FsmVector3 vectorPosition;
		public FsmFloat longitude;
		public FsmFloat latitude;
		public FsmFloat altitude;
		public FsmFloat horizontalAccuracy;
		public FsmFloat verticalAccuracy;
		public FsmEvent errorEvent;
	}
}
