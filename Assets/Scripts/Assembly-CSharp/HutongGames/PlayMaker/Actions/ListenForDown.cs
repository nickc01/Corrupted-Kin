using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ListenForDown : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public FsmEvent wasPressed;
		public FsmEvent wasReleased;
		public FsmEvent isPressed;
		public FsmEvent isNotPressed;
		public FsmBool isPressedBool;
		public bool stateEntryOnly;
	}
}
