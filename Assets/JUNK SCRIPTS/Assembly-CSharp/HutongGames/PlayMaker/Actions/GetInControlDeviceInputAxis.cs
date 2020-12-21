using HutongGames.PlayMaker;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	public class GetInControlDeviceInputAxis : FsmStateAction
	{
		public FsmInt deviceIndex;
		public InputControlType axis;
		public FsmFloat multiplier;
		public FsmFloat store;
		public bool everyFrame;
	}
}
