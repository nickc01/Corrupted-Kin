using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatCompare : FsmStateAction
	{
		public FsmFloat float1;
		public FsmFloat float2;
		public FsmFloat tolerance;
		public FsmEvent equal;
		public FsmEvent lessThan;
		public FsmEvent greaterThan;
		public bool everyFrame;
	}
}
