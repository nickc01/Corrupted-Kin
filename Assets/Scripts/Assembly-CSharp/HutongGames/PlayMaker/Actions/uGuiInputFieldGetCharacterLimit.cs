using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldGetCharacterLimit : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt characterLimit;
		public FsmEvent hasNoLimitEvent;
		public FsmEvent isLimitedEvent;
		public bool everyFrame;
	}
}
