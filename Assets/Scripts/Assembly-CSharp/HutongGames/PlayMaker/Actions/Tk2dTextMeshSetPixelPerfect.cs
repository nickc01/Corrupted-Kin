using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetPixelPerfect : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool pixelPerfect;
		public FsmBool commit;
		public bool everyframe;
	}
}
