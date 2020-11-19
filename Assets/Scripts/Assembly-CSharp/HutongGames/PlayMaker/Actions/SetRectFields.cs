using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetRectFields : FsmStateAction
	{
		public FsmRect rectVariable;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat width;
		public FsmFloat height;
		public bool everyFrame;
	}
}
