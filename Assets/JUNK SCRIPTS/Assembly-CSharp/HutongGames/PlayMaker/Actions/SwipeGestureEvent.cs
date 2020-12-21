using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SwipeGestureEvent : FsmStateAction
	{
		public FsmFloat minSwipeDistance;
		public FsmEvent swipeLeftEvent;
		public FsmEvent swipeRightEvent;
		public FsmEvent swipeUpEvent;
		public FsmEvent swipeDownEvent;
	}
}
