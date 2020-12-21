using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Wait : FsmStateAction
	{
		public FsmFloat time;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
