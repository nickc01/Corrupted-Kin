using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ListenForMenuActions : FsmStateAction
	{
		public FsmEventTarget eventTarget;
		public FsmEvent submitPressed;
		public FsmEvent cancelPressed;
		public FsmBool ignoreAttack;
	}
}
