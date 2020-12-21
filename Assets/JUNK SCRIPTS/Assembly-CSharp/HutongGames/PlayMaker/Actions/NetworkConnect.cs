using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkConnect : FsmStateAction
	{
		public FsmString remoteIP;
		public FsmInt remotePort;
		public FsmString password;
		public FsmEvent errorEvent;
		public FsmString errorString;
	}
}
