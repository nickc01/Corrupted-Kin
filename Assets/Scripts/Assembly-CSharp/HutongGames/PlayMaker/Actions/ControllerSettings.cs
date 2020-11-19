using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ControllerSettings : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat height;
		public FsmFloat radius;
		public FsmFloat slopeLimit;
		public FsmFloat stepOffset;
		public FsmVector3 center;
		public FsmBool detectCollisions;
		public bool everyFrame;
	}
}
