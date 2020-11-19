using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class InvokeMethod : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString behaviour;
		public FsmString methodName;
		public FsmFloat delay;
		public FsmBool repeating;
		public FsmFloat repeatDelay;
		public FsmBool cancelOnExit;
	}
}
