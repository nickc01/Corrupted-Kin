using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CallMethod : FsmStateAction
	{
		public FsmObject behaviour;
		public FsmString methodName;
		public FsmVar[] parameters;
		public FsmVar storeResult;
		public bool everyFrame;
		public bool manualUI;
	}
}
