using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatAddV2 : FsmStateAction
	{
		public FsmFloat floatVariable;
		public FsmFloat add;
		public bool everyFrame;
		public bool perSecond;
		public bool fixedUpdate;
		public FsmBool activeBool;
	}
}
