using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArraySet : FsmStateAction
	{
		public FsmArray array;
		public FsmInt index;
		public FsmVar value;
		public bool everyFrame;
		public FsmEvent indexOutOfRange;
	}
}
