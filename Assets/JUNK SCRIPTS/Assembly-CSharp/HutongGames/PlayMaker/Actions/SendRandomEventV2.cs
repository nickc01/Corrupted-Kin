using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendRandomEventV2 : FsmStateAction
	{
		public FsmEvent[] events;
		public FsmFloat[] weights;
		public FsmInt[] trackingInts;
		public FsmInt[] eventMax;
	}
}
