using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCurrentStateInfoIsTag : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public FsmString tag;
		public FsmBool tagMatch;
		public FsmEvent tagMatchEvent;
		public FsmEvent tagDoNotMatchEvent;
	}
}
