using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorLayerWeight : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public FsmFloat layerWeight;
		public bool everyFrame;
	}
}
