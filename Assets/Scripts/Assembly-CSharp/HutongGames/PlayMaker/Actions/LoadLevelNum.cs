using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LoadLevelNum : FsmStateAction
	{
		public FsmInt levelIndex;
		public bool additive;
		public FsmEvent loadedEvent;
		public FsmBool dontDestroyOnLoad;
		public FsmEvent failedEvent;
	}
}
