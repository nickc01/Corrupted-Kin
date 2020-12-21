using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class LookAt2d : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 vector2Target;
		public FsmVector3 vector3Target;
		public FsmFloat rotationOffset;
		public FsmBool debug;
		public FsmColor debugLineColor;
		public bool everyFrame;
	}
}
