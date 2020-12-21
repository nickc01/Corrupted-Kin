using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GUILayoutToolbar : GUILayoutAction
	{
		public FsmInt numButtons;
		public FsmInt selectedButton;
		public FsmEvent[] buttonEventsArray;
		public FsmTexture[] imagesArray;
		public FsmString[] textsArray;
		public FsmString[] tooltipsArray;
		public FsmString style;
		public bool everyFrame;
	}
}
