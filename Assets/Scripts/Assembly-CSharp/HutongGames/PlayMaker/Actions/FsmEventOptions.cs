using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmEventOptions : FsmStateAction
	{
		public PlayMakerFSM sendToFsmComponent;
		public FsmGameObject sendToGameObject;
		public FsmString fsmName;
		public FsmBool sendToChildren;
		public FsmBool broadcastToAll;
	}
}
