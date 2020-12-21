using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmStateSwitch : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmString fsmName;
		public FsmString[] compareTo;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
