using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CheckTargetDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmEvent aboveEvent;
		public FsmEvent belowEvent;
		public FsmEvent rightEvent;
		public FsmEvent leftEvent;
		public FsmBool aboveBool;
		public FsmBool belowBool;
		public FsmBool rightBool;
		public FsmBool leftBool;
		public bool everyFrame;
	}
}
