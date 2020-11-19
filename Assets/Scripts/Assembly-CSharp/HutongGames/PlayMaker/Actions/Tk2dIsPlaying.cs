using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dIsPlaying : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString clipName;
		public FsmBool isPlaying;
		public FsmEvent isPlayingEvent;
		public FsmEvent isNotPlayingEvent;
		public bool everyframe;
	}
}
