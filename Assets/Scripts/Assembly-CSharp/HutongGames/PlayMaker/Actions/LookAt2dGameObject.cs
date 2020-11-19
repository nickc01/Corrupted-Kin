using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LookAt2dGameObject : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmFloat rotationOffset;
		public FsmBool debug;
		public FsmColor debugLineColor;
		public bool everyFrame;
	}
}
