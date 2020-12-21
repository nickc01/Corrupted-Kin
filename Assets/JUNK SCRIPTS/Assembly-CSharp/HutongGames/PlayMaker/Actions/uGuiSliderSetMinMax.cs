using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiSliderSetMinMax : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat minValue;
		public FsmFloat maxValue;
		public FsmBool resetOnExit;
		public bool everyFrame;
	}
}
