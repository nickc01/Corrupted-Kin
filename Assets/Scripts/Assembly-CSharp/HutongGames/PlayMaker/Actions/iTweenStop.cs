using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenStop : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public iTweenFSMType iTweenType;
		public bool includeChildren;
		public bool inScene;
	}
}
