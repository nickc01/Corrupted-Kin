using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FlingObjects : RigidBody2dActionBase
	{
		public FsmGameObject containerObject;
		public FsmVector3 adjustPosition;
		public FsmBool randomisePosition;
		public FsmFloat speedMin;
		public FsmFloat speedMax;
		public FsmFloat angleMin;
		public FsmFloat angleMax;
	}
}
