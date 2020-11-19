using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenFadeTo : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmFloat alpha;
		public FsmBool includeChildren;
		public FsmString namedValueColor;
		public FsmFloat time;
		public FsmFloat delay;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
	}
}
