using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class WaitRandom : FsmStateAction
	{
		public FsmFloat timeMin;
		public FsmFloat timeMax;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
