using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetTextureGradient : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt textureGradient;
		public FsmBool commit;
		public bool everyframe;
	}
}
