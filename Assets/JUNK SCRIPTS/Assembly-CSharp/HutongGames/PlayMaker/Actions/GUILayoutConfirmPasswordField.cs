using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GUILayoutConfirmPasswordField : GUILayoutAction
	{
		public FsmString text;
		public FsmInt maxLength;
		public FsmString style;
		public FsmEvent changedEvent;
		public FsmString mask;
		public FsmBool confirm;
		public FsmString password;
	}
}
