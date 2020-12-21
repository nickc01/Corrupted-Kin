using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ColorRamp : FsmStateAction
	{
		public FsmColor[] colors;
		public FsmFloat sampleAt;
		public FsmColor storeColor;
		public bool everyFrame;
	}
}
