using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GUILayoutBeginScrollView : GUILayoutAction
	{
		public FsmVector2 scrollPosition;
		public FsmBool horizontalScrollbar;
		public FsmBool verticalScrollbar;
		public FsmBool useCustomStyle;
		public FsmString horizontalStyle;
		public FsmString verticalStyle;
		public FsmString backgroundStyle;
	}
}
