using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IsPointerOverUiObject : FsmStateAction
	{
		public FsmInt pointerId;
		public FsmEvent pointerOverUI;
		public FsmEvent pointerNotOverUI;
		public FsmBool isPointerOverUI;
		public bool everyFrame;
	}
}
