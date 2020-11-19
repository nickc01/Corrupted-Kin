using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ConvertFloatToInt : FsmStateAction
	{
		public enum FloatRounding
		{
			RoundDown = 0,
			RoundUp = 1,
			Nearest = 2,
		}

		public FsmFloat floatVariable;
		public FsmInt intVariable;
		public FloatRounding rounding;
		public bool everyFrame;
	}
}
