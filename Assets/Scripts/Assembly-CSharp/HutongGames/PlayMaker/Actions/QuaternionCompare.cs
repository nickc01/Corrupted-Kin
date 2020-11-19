using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class QuaternionCompare : QuaternionBaseAction
	{
		public FsmQuaternion Quaternion1;
		public FsmQuaternion Quaternion2;
		public FsmBool equal;
		public FsmEvent equalEvent;
		public FsmEvent notEqualEvent;
	}
}
