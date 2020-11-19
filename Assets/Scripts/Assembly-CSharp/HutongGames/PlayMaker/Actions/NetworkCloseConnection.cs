using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkCloseConnection : FsmStateAction
	{
		public FsmInt connectionIndex;
		public FsmString connectionGUID;
		public bool sendDisconnectionNotification;
	}
}
