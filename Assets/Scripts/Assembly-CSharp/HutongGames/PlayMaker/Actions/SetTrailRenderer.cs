using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTrailRenderer : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat startWidth;
		public FsmFloat endWidth;
		public FsmFloat time;
		public bool everyFrame;
	}
}
