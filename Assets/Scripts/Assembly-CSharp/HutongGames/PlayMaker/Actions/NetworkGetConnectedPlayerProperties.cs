using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkGetConnectedPlayerProperties : FsmStateAction
	{
		public FsmInt index;
		public FsmString IpAddress;
		public FsmInt port;
		public FsmString guid;
		public FsmString externalIPAddress;
		public FsmInt externalPort;
	}
}
