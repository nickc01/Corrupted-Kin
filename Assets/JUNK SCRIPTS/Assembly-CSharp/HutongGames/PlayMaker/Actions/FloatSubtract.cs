using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatSubtract : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat subtract;
		public bool everyFrame;
		public bool perSecond;
	}
}
