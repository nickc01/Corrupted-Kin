using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldSetSelectionColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor selectionColor;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
