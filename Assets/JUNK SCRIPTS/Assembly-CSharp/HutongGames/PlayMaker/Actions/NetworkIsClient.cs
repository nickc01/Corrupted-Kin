using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkIsClient : FsmStateAction
	{
		public FsmBool isClient;
		public FsmEvent isClientEvent;
		public FsmEvent isNotClientEvent;
	}
}
