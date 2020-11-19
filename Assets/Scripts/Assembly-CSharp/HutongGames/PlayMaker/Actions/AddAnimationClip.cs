using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddAnimationClip : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmObject animationClip;
		public FsmString animationName;
		public FsmInt firstFrame;
		public FsmInt lastFrame;
		public FsmBool addLoopFrame;
	}
}
