using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LoadLevel : FsmStateAction
	{
		public FsmString levelName;
		public bool additive;
		public bool async;
		public FsmEvent loadedEvent;
		public FsmBool dontDestroyOnLoad;
		public FsmEvent failedEvent;
	}
}
