using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertSecondsToString : FsmStateAction
	{
		public FsmFloat secondsVariable;
		public FsmString stringVariable;
		public FsmString format;
		public bool everyFrame;
	}
}
