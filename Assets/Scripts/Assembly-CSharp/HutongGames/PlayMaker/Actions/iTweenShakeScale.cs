using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenShakeScale : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmVector3 vector;
		public FsmFloat time;
		public FsmFloat delay;
		public iTween.LoopType loopType;
	}
}
