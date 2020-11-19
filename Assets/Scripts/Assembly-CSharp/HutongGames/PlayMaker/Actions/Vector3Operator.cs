using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3Operator : FsmStateAction
	{
		public enum Vector3Operation
		{
			DotProduct = 0,
			CrossProduct = 1,
			Distance = 2,
			Angle = 3,
			Project = 4,
			Reflect = 5,
			Add = 6,
			Subtract = 7,
			Multiply = 8,
			Divide = 9,
			Min = 10,
			Max = 11,
		}

		public FsmVector3 vector1;
		public FsmVector3 vector2;
		public Vector3Operation operation;
		public FsmVector3 storeVector3Result;
		public FsmFloat storeFloatResult;
		public bool everyFrame;
	}
}
