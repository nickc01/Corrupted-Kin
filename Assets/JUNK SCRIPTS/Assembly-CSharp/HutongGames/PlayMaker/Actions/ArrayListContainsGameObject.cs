using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListContainsGameObject : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmString gameObjectName;
		public FsmString withTag;
		public FsmGameObject result;
		public FsmInt resultIndex;
		public FsmBool isContained;
		public FsmEvent isContainedEvent;
		public FsmEvent isNotContainedEvent;
	}
}
