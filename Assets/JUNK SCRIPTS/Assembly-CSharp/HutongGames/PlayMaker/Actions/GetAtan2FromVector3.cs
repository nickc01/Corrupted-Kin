using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAtan2FromVector3 : FsmStateAction
	{
		public enum aTan2EnumAxis
		{
			x = 0,
			y = 1,
			z = 2,
		}

		public FsmVector3 vector3;
		public aTan2EnumAxis xAxis;
		public aTan2EnumAxis yAxis;
		public FsmFloat angle;
		public FsmBool RadToDeg;
		public bool everyFrame;
	}
}
