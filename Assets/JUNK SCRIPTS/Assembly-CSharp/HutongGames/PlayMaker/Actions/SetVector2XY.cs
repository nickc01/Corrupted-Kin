using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetVector2XY : FsmStateAction
	{
		public FsmVector2 vector2Variable;
		public FsmVector2 vector2Value;
		public FsmFloat x;
		public FsmFloat y;
		public bool everyFrame;
	}
}
