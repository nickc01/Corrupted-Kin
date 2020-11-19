using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddComponent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString component;
		public FsmObject storeComponent;
		public FsmBool removeOnExit;
	}
}
