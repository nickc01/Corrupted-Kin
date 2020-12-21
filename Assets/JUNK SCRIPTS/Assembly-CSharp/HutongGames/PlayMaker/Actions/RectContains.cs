using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectContains : FsmStateAction
	{
		public FsmRect rectangle;
		public FsmVector3 point;
		public FsmFloat x;
		public FsmFloat y;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
