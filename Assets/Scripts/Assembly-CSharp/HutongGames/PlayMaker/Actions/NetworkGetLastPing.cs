using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkGetLastPing : FsmStateAction
	{
		public FsmInt playerIndex;
		public bool cachePlayerReference;
		public bool everyFrame;
		public FsmInt lastPing;
		public FsmEvent PlayerNotFoundEvent;
		public FsmEvent PlayerFoundEvent;
	}
}
