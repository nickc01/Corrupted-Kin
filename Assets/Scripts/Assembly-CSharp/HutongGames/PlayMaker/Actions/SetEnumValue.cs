using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetEnumValue : FsmStateAction
	{
		public FsmEnum enumVariable;
		public FsmEnum enumValue;
		public bool everyFrame;
	}
}
