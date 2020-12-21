using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StartServer : FsmStateAction
	{
		public FsmInt connections;
		public FsmInt listenPort;
		public FsmString incomingPassword;
		public FsmBool useNAT;
		public FsmBool useSecurityLayer;
		public FsmBool runInBackground;
		public FsmEvent errorEvent;
		public FsmString errorString;
	}
}
