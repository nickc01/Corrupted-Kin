using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GUILayoutEmailField : GUILayoutAction
	{
		public FsmString text;
		public FsmInt maxLength;
		public FsmString style;
		public FsmEvent changedEvent;
		public FsmBool valid;
	}
}
