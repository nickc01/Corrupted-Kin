using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetTouchInfo : FsmStateAction
	{
		public FsmInt fingerId;
		public FsmBool normalize;
		public FsmVector3 storePosition;
		public FsmFloat storeX;
		public FsmFloat storeY;
		public FsmVector3 storeDeltaPosition;
		public FsmFloat storeDeltaX;
		public FsmFloat storeDeltaY;
		public FsmFloat storeDeltaTime;
		public FsmInt storeTapCount;
		public bool everyFrame;
	}
}
