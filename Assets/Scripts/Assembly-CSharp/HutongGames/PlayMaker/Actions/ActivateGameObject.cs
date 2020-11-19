using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ActivateGameObject : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool activate;
		public FsmBool recursive;
		public bool resetOnExit;
		public bool everyFrame;
	}
}
