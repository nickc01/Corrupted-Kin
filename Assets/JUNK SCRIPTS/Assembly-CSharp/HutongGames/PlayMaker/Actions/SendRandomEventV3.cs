using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendRandomEventV3 : FsmStateAction
	{
		public FsmEvent[] events;
		public FsmFloat[] weights;
		public FsmInt[] trackingInts;
		public FsmInt[] eventMax;
		public FsmInt[] trackingIntsMissed;
		public FsmInt[] missedMax;
	}
}
