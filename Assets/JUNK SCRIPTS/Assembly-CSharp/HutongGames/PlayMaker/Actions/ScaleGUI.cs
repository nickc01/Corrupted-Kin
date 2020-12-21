using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScaleGUI : FsmStateAction
	{
		public FsmFloat scaleX;
		public FsmFloat scaleY;
		public FsmFloat pivotX;
		public FsmFloat pivotY;
		public bool normalized;
		public bool applyGlobally;
	}
}
