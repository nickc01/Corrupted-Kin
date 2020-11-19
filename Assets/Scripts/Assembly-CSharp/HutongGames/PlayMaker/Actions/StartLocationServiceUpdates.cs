using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StartLocationServiceUpdates : FsmStateAction
	{
		public FsmFloat maxWait;
		public FsmFloat desiredAccuracy;
		public FsmFloat updateDistance;
		public FsmEvent successEvent;
		public FsmEvent failedEvent;
	}
}
