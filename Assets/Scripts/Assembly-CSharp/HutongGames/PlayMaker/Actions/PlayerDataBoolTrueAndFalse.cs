using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayerDataBoolTrueAndFalse : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString trueBool;
		public FsmString falseBool;
		public FsmEvent isTrue;
		public FsmEvent isFalse;
	}
}
