using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayListGetNearestFloatValue : ArrayListActions
	{
		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmFloat floatValue;
		public bool everyframe;
		public FsmInt nearestIndex;
		public FsmFloat nearestValue;
	}
}
