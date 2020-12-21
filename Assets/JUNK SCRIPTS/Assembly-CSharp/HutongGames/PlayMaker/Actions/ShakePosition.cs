using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ShakePosition : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 extents;
		public FsmFloat duration;
		public FsmBool isLooping;
		public FsmEvent stopEvent;
	}
}
