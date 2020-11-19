using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkPeerTypeSwitch : FsmStateAction
	{
		public FsmEvent isDisconnected;
		public FsmEvent isServer;
		public FsmEvent isClient;
		public FsmEvent isConnecting;
		public bool everyFrame;
	}
}
