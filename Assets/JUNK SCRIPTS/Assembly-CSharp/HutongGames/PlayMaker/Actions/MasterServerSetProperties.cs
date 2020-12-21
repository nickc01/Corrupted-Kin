using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MasterServerSetProperties : FsmStateAction
	{
		public FsmString ipAddress;
		public FsmInt port;
		public FsmInt updateRate;
		public FsmBool dedicatedServer;
	}
}
