using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetColorRGBA : FsmStateAction
	{
		public FsmColor colorVariable;
		public FsmFloat red;
		public FsmFloat green;
		public FsmFloat blue;
		public FsmFloat alpha;
		public bool everyFrame;
	}
}
