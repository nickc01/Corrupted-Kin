using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetColors : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor mainColor;
		public FsmColor gradientColor;
		public FsmBool useGradient;
		public FsmBool commit;
		public bool everyframe;
	}
}
