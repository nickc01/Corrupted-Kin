using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RandomWait : FsmStateAction
	{
		public FsmFloat min;
		public FsmFloat max;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
