using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetClosestGameObject : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmGameObject distanceFrom;
		public FsmVector3 orDistanceFromVector3;
		public bool everyframe;
		public FsmGameObject closestGameObject;
		public FsmInt closestIndex;
	}
}
