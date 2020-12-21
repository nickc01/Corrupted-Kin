using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CallStaticMethod : FsmStateAction
	{
		public FsmString className;
		public FsmString methodName;
		public FsmVar[] parameters;
		public FsmVar storeResult;
		public bool everyFrame;
	}
}
