using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CameraFadeOut : FsmStateAction
	{
		public FsmColor color;
		public FsmFloat time;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
