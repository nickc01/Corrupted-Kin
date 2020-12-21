using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StartCoroutine : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString behaviour;
		public FunctionCall functionCall;
		public bool stopOnExit;
	}
}
