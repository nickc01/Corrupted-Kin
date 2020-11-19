using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCurrentTransitionInfo : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public new FsmString name;
		public FsmInt nameHash;
		public FsmInt userNameHash;
		public FsmFloat normalizedTime;
	}
}
