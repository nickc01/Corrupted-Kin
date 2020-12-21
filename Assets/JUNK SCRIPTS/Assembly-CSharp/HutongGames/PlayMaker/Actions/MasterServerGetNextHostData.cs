using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MasterServerGetNextHostData : FsmStateAction
	{
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
		public FsmInt index;
		public FsmBool useNat;
		public FsmString gameType;
		public FsmString gameName;
		public FsmInt connectedPlayers;
		public FsmInt playerLimit;
		public FsmString ipAddress;
		public FsmInt port;
		public FsmBool passwordProtected;
		public FsmString comment;
		public FsmString guid;
	}
}
