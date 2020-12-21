using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddScript : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString script;
		public FsmBool removeOnExit;
	}
}
