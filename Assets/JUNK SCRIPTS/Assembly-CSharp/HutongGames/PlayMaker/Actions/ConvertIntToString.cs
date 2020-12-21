using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertIntToString : FsmStateAction
	{
		public FsmInt intVariable;
		public FsmString stringVariable;
		public FsmString format;
		public bool everyFrame;
	}
}
