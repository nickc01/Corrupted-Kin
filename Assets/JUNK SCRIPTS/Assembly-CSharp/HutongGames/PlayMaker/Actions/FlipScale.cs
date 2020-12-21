using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FlipScale : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public bool flipHorizontally;
		public bool flipVertically;
		public bool everyFrame;
		public bool lateUpdate;
	}
}
