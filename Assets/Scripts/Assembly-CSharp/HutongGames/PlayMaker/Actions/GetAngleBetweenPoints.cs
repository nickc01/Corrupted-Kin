using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAngleBetweenPoints : FsmStateAction
	{
		public FsmVector3 point1;
		public FsmVector3 point2;
		public FsmFloat storeAngle;
		public bool everyFrame;
	}
}
