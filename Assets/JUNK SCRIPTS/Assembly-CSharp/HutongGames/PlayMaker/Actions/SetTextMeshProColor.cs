using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTextMeshProColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor color;
		public bool everyFrame;
	}
}
