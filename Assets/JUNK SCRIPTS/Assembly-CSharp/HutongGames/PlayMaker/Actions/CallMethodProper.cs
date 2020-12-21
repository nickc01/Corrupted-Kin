using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CallMethodProper : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString behaviour;
		public FsmString methodName;
		public FsmVar[] parameters;
		public FsmVar storeResult;
	}
}
