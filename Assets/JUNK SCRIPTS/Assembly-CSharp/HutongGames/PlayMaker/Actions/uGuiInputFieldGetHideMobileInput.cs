using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldGetHideMobileInput : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool hideMobileInput;
		public FsmEvent mobileInputHiddenEvent;
		public FsmEvent mobileInputShownEvent;
	}
}
