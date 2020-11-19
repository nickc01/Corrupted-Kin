using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCurrentTransitionInfoIsName : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public new FsmString name;
		public FsmBool nameMatch;
		public FsmEvent nameMatchEvent;
		public FsmEvent nameDoNotMatchEvent;
	}
}
