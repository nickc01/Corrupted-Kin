using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RandomInt : FsmStateAction
	{
		public FsmInt min;
		public FsmInt max;
		public FsmInt storeResult;
		public bool inclusiveMax;
	}
}
