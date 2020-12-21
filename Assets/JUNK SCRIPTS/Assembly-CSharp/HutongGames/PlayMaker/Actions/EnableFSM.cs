using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class EnableFSM : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmBool enable;
		public FsmBool resetOnExit;
	}
}
