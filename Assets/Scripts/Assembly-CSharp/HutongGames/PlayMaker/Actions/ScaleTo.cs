using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScaleTo : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 target;
		public FsmFloat duration;
		public FsmFloat delay;
		public ScaleToCurves curve;
	}
}
