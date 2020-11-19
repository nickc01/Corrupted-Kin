using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetYDistance : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
