using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetButtonUp : FsmStateAction
	{
		public FsmString buttonName;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
	}
}
