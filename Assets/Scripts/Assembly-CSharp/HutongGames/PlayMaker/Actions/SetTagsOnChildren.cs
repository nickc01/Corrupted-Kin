using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTagsOnChildren : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString tag;
		public FsmString filterByComponent;
	}
}
