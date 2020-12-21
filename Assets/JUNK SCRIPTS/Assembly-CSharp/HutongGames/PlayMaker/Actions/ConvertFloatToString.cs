using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertFloatToString : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmString stringVariable;
		public FsmString format;
		public bool everyFrame;
	}
}
