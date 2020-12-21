using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoxColliderOffset : FsmStateAction
	{
		public FsmOwnerDefault gameObject1;
		public FsmVector2 offsetVector2;
		public FsmFloat offsetX;
		public FsmFloat offsetY;
		public bool everyFrame;
	}
}
