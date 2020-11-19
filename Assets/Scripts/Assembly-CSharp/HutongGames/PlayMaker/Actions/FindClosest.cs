using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FindClosest : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString withTag;
		public FsmBool ignoreOwner;
		public FsmBool mustBeVisible;
		public FsmGameObject storeObject;
		public FsmFloat storeDistance;
		public bool everyFrame;
	}
}
