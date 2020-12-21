using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkIsServer : FsmStateAction
	{
		public FsmBool isServer;
		public FsmEvent isServerEvent;
		public FsmEvent isNotServerEvent;
	}
}
