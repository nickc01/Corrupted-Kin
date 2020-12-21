using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IntOperator : FsmStateAction
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

		public FsmInt integer1;
		public FsmInt integer2;
		public Operation operation;
		public FsmInt storeResult;
		public bool everyFrame;
	}
}
