using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetFarthestGameObject : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmGameObject distanceFrom;
		public FsmVector3 orDistanceFromVector3;
		public bool everyframe;
		public FsmGameObject farthestGameObject;
		public FsmInt farthestIndex;
	}
}
