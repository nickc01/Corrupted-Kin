using HutongGames.PlayMaker;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	public class GetInControlDeviceInputButton : FsmStateAction
	{
		public FsmInt deviceIndex;
		public InputControlType axis;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
