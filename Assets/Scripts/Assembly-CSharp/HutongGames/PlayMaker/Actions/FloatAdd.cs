using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatAdd : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat add;
		public bool everyFrame;
		public bool perSecond;
	}
}
