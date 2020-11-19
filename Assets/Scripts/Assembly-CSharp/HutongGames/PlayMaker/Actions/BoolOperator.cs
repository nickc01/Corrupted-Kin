using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BoolOperator : FsmStateAction
	{
		public enum Operation
		{
			AND = 0,
			NAND = 1,
			OR = 2,
			XOR = 3,
		}

		public FsmBool bool1;
		public FsmBool bool2;
		public Operation operation;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
