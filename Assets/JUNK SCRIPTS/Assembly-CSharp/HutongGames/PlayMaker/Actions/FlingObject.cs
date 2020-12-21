using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FlingObject : RigidBody2dActionBase
	{
		public FsmOwnerDefault flungObject;
		public FsmFloat speedMin;
		public FsmFloat speedMax;
		public FsmFloat angleMin;
		public FsmFloat angleMax;
	}
}
