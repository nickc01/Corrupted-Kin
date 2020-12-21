using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetFsmState : FsmStateAction
	{
		public new PlayMakerFSM fsmComponent;
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString storeResult;
		public bool everyFrame;
	}
}
