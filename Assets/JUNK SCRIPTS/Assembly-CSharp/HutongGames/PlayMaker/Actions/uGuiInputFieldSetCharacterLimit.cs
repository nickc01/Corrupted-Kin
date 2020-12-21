using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldSetCharacterLimit : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt characterLimit;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
