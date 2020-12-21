using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MasterServerGetProperties : FsmStateAction
	{
		public FsmString ipAddress;
		public FsmInt port;
		public FsmInt updateRate;
		public FsmBool dedicatedServer;
		public FsmEvent isDedicatedServerEvent;
		public FsmEvent isNotDedicatedServerEvent;
	}
}
