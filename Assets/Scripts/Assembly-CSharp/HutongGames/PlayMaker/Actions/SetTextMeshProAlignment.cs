using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTextMeshProAlignment : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool topLeft;
		public FsmBool topRight;
		public FsmBool topCentre;
		public FsmBool topJustified;
		public FsmBool centreLeft;
		public FsmBool centreRight;
		public FsmBool centreCentre;
		public FsmBool centreJustified;
		public FsmBool bottomLeft;
		public FsmBool bottomRight;
		public FsmBool bottomCentre;
		public FsmBool bottomJustified;
	}
}
