using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorIsParameterControlledByCurve : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString parameterName;
		public FsmBool isControlledByCurve;
		public FsmEvent isControlledByCurveEvent;
		public FsmEvent isNotControlledByCurveEvent;
	}
}
