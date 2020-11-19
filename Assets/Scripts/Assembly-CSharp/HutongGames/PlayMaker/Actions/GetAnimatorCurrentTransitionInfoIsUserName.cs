using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCurrentTransitionInfoIsUserName : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public FsmString userName;
		public FsmBool nameMatch;
		public FsmEvent nameMatchEvent;
		public FsmEvent nameDoNotMatchEvent;
	}
}
