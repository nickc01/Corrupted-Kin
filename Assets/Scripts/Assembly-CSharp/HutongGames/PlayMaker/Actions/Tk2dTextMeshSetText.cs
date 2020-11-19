using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetText : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString text;
		public FsmBool commit;
		public bool everyframe;
	}
}
