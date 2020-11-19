using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ColorInterpolate : FsmStateAction
	{
		public FsmColor[] colors;
		public FsmFloat time;
		public FsmColor storeColor;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
