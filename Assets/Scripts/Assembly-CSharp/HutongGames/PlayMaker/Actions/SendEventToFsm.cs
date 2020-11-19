using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEventToFsm : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString sendEvent;
		public FsmFloat delay;
	}
}
