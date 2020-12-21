using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayDeleteAt : FsmStateAction
	{
		public FsmArray array;
		public FsmInt index;
		public FsmEvent indexOutOfRangeEvent;
	}
}
