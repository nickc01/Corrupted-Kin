using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class HasComponent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString component;
		public FsmBool removeOnExit;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool store;
		public bool everyFrame;
	}
}
