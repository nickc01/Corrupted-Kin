using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetColorRGBA : FsmStateAction
	{
		public FsmColor color;
		public FsmFloat storeRed;
		public FsmFloat storeGreen;
		public FsmFloat storeBlue;
		public FsmFloat storeAlpha;
		public bool everyFrame;
	}
}
