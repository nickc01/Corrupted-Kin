using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CompareNames : FsmStateAction
	{
		public new FsmString name;
		public FsmArray strings;
		public FsmEventTarget target;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
	}
}
