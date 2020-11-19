using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DistanceBetweenPoints : FsmStateAction
	{
		public FsmFloat distanceResult;
		public FsmVector3 point1;
		public FsmVector3 point2;
		public bool ignoreZ;
		public bool everyFrame;
	}
}
