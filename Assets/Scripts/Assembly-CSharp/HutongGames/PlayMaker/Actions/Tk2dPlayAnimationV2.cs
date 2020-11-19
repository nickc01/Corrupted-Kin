using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dPlayAnimationV2 : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animLibName;
		public FsmString clipName;
		public bool doNotResetCurrentClip;
	}
}
