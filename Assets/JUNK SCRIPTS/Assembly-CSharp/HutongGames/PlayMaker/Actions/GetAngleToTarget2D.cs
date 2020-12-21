using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAngleToTarget2D : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmFloat offsetX;
		public FsmFloat offsetY;
		public FsmFloat storeAngle;
		public bool everyFrame;
	}
}
