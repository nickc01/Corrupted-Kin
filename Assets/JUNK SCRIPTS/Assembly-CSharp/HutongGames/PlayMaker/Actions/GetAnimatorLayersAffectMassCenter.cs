using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorLayersAffectMassCenter : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool affectMassCenter;
		public FsmEvent affectMassCenterEvent;
		public FsmEvent doNotAffectMassCenterEvent;
	}
}
