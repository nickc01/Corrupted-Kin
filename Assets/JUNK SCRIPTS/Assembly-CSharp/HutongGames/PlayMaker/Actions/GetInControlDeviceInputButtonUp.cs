using HutongGames.PlayMaker;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	public class GetInControlDeviceInputButtonUp : FsmStateAction
	{
		public FsmInt deviceIndex;
		public InputControlType axis;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
	}
}
