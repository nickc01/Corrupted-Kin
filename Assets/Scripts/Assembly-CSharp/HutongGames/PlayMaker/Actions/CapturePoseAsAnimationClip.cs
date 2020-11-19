using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CapturePoseAsAnimationClip : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool position;
		public FsmBool rotation;
		public FsmBool scale;
		public FsmObject storeAnimationClip;
	}
}
