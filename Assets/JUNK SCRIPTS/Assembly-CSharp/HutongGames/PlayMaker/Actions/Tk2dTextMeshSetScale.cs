using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetScale : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 scale;
		public FsmBool commit;
		public bool everyframe;
	}
}
