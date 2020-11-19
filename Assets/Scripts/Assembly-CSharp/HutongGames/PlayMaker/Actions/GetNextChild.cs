using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetNextChild : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject storeNextChild;
		public FsmEvent loopEvent;
		public FsmEvent finishedEvent;
	}
}
