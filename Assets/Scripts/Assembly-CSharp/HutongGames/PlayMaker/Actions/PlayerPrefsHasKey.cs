using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayerPrefsHasKey : FsmStateAction
	{
		public FsmString key;
		public FsmBool variable;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
	}
}
