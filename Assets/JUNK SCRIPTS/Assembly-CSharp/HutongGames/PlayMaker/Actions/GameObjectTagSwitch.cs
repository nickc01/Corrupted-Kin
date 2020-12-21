using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectTagSwitch : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmString[] compareTo;
		public FsmEvent[] sendEvent;
		public bool everyFrame;
	}
}
