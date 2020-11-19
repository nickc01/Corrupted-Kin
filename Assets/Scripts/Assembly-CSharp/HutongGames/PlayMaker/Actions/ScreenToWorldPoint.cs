using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScreenToWorldPoint : FsmStateAction
	{
		public FsmVector3 screenVector;
		public FsmFloat screenX;
		public FsmFloat screenY;
		public FsmFloat screenZ;
		public FsmBool normalized;
		public FsmVector3 storeWorldVector;
		public FsmFloat storeWorldX;
		public FsmFloat storeWorldY;
		public FsmFloat storeWorldZ;
		public bool everyFrame;
	}
}
