using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetVector2XY : FsmStateAction
	{
		public FsmVector2 vector2Variable;
		public FsmFloat storeX;
		public FsmFloat storeY;
		public bool everyFrame;
	}
}
