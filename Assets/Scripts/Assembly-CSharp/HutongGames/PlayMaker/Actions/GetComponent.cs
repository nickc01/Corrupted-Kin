using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetComponent : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmObject storeComponent;
		public bool everyFrame;
	}
}
