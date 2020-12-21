using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayContains : FsmStateAction
	{
		public FsmArray array;
		public FsmVar value;
		public FsmInt index;
		public FsmBool isContained;
		public FsmEvent isContainedEvent;
		public FsmEvent isNotContainedEvent;
	}
}
