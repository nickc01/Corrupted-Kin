using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGameObjectSelf : FsmStateAction
	{
		public FsmGameObject variable;
		public FsmOwnerDefault gameObject;
		public bool everyFrame;
	}
}
