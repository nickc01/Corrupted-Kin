using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CameraFadeInWithDelay : FsmStateAction
	{
		public FsmColor color;
		public FsmFloat delay;
		public FsmFloat time;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
