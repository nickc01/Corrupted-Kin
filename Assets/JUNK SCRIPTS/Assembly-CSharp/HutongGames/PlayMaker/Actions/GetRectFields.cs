using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRectFields : FsmStateAction
	{
		public FsmRect rectVariable;
		public FsmFloat storeX;
		public FsmFloat storeY;
		public FsmFloat storeWidth;
		public FsmFloat storeHeight;
		public bool everyFrame;
	}
}
