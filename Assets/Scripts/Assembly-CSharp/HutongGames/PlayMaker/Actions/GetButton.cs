using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetButton : FsmStateAction
	{
		public FsmString buttonName;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
