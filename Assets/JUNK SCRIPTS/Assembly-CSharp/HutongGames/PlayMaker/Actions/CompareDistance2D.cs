using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CompareDistance2D : FsmStateAction
	{
		public FsmVector2 point1;
		public FsmVector2 point2;
		public FsmFloat knownDistance;
		public bool everyFrame;
	}
}
