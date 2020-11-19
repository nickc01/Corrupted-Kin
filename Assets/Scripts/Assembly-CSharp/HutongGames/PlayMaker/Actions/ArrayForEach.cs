using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayForEach : RunFSMAction
	{
		public FsmArray array;
		public FsmVar storeItem;
		public FsmTemplateControl fsmTemplateControl;
		public FsmEvent finishEvent;
	}
}
