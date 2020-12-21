using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimatorFollow : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat minimumDistance;
		public FsmFloat speedDampTime;
		public FsmFloat directionDampTime;
	}
}
