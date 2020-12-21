using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DeviceShakeEvent : FsmStateAction
	{
		public FsmFloat shakeThreshold;
		public FsmEvent sendEvent;
	}
}
