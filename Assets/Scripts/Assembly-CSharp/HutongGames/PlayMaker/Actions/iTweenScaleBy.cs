using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenScaleBy : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmVector3 vector;
		public FsmFloat time;
		public FsmFloat delay;
		public FsmFloat speed;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
	}
}
