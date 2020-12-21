using HutongGames.PlayMaker;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	public class GetInControlDeviceInputButtonDown : FsmStateAction
	{
		public FsmInt deviceIndex;
		public InputControlType axis;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
	}
}
