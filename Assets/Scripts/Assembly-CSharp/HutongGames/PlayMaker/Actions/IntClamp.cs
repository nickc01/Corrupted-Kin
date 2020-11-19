using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntClamp : FsmStateAction
	{
		public FsmInt intVariable;
		public FsmInt minValue;
		public FsmInt maxValue;
		public bool everyFrame;
	}
}
