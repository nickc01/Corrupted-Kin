using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetDistance : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
