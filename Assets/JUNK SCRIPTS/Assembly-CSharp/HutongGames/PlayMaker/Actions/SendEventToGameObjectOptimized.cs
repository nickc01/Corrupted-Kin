using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEventToGameObjectOptimized : FsmStateAction
	{
		public FsmOwnerDefault target;
		public FsmString sendEvent;
		public bool everyFrame;
	}
}
