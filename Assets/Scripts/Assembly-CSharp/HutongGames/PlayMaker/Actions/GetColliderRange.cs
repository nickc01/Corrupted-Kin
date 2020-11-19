using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetColliderRange : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat minX;
		public FsmFloat maxX;
		public FsmFloat minY;
		public FsmFloat maxY;
		public bool everyFrame;
	}
}
