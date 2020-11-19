using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenLookTo : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmGameObject transformTarget;
		public FsmVector3 vectorTarget;
		public FsmFloat time;
		public FsmFloat delay;
		public FsmFloat speed;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
		public iTweenFsmAction.AxisRestriction axis;
	}
}
