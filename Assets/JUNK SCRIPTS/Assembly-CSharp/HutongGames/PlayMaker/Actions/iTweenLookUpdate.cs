using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenLookUpdate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject transformTarget;
		public FsmVector3 vectorTarget;
		public FsmFloat time;
		public iTweenFsmAction.AxisRestriction axis;
	}
}
