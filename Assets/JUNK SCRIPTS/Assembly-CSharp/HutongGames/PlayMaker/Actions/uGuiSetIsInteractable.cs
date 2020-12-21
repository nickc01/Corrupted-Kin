using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiSetIsInteractable : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isInteractable;
		public FsmBool resetOnExit;
	}
}
