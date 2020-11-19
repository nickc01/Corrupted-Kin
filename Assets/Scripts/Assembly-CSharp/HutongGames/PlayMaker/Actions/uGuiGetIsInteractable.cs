using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiGetIsInteractable : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isInteractable;
		public FsmEvent isInteractableEvent;
		public FsmEvent isNotInteractableEvent;
	}
}
