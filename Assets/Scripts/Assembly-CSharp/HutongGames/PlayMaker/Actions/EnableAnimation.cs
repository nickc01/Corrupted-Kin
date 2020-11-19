using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class EnableAnimation : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public FsmBool enable;
		public FsmBool resetOnExit;
	}
}
