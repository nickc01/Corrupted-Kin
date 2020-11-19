using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3RotateTowards : FsmStateAction
	{
		public FsmVector3 currentDirection;
		public FsmVector3 targetDirection;
		public FsmFloat rotateSpeed;
		public FsmFloat maxMagnitude;
	}
}
