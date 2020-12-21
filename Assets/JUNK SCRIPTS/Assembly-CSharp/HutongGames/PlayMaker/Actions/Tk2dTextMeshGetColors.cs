using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshGetColors : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor mainColor;
		public FsmColor gradientColor;
		public FsmBool useGradient;
		public bool everyframe;
	}
}
