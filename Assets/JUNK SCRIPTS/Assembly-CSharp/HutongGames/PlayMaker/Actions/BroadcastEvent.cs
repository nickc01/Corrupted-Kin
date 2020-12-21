using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BroadcastEvent : FsmStateAction
	{
		public FsmString broadcastEvent;
		public FsmGameObject gameObject;
		public FsmBool sendToChildren;
		public FsmBool excludeSelf;
	}
}
