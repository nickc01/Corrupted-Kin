using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class QuaternionRotateTowards : QuaternionBaseAction
	{
		public FsmQuaternion fromQuaternion;
		public FsmQuaternion toQuaternion;
		public FsmFloat maxDegreesDelta;
		public FsmQuaternion storeResult;
	}
}
