using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatClamp : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat minValue;
		public FsmFloat maxValue;
		public bool everyFrame;
	}
}
