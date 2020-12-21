using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetClosestGameObjectInSight : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmGameObject distanceFrom;
		public FsmVector3 orDistanceFromVector3;
		public bool everyframe;
		public FsmOwnerDefault fromGameObject;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public FsmGameObject closestGameObject;
		public FsmInt closestIndex;
	}
}
