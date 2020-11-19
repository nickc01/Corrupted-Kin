using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectOverlaps : FsmStateAction
	{
		public FsmRect rect1;
		public FsmRect rect2;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
