using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class QuaternionSlerp : QuaternionBaseAction
	{
		public FsmQuaternion fromQuaternion;
		public FsmQuaternion toQuaternion;
		public FsmFloat amount;
		public FsmQuaternion storeResult;
	}
}
