using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DistanceBetweenPoints2D : FsmStateAction
	{
		public FsmFloat distanceResult;
		public FsmVector2 point1;
		public FsmVector2 point2;
		public bool everyFrame;
	}
}
