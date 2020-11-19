using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshSetMaxChars : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt maxChars;
		public FsmBool commit;
		public bool everyframe;
	}
}
