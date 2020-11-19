using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RotateGUI : FsmStateAction
	{
		public FsmFloat angle;
		public FsmFloat pivotX;
		public FsmFloat pivotY;
		public bool normalized;
		public bool applyGlobally;
	}
}
