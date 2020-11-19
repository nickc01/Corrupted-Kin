using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatOperator : FsmStateAction
	{
		public enum Operation
		{
			Add = 0,
			Subtract = 1,
			Multiply = 2,
			Divide = 3,
			Min = 4,
			Max = 5,
		}

		public FsmFloat float1;
		public FsmFloat float2;
		public Operation operation;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
