using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorCurrentStateInfoIsName : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmInt layerIndex;
		public new FsmString name;
		public FsmBool isMatching;
		public FsmEvent nameMatchEvent;
		public FsmEvent nameDoNotMatchEvent;
	}
}
