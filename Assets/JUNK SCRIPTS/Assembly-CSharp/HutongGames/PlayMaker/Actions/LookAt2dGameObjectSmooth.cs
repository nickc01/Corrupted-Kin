using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LookAt2dGameObjectSmooth : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmFloat rotationOffset;
		public FsmFloat speed;
		public FsmBool debug;
		public FsmColor debugLineColor;
	}
}
