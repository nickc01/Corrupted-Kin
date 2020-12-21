using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetJointBreak2dInfo : FsmStateAction
	{
		public FsmObject brokenJoint;
		public FsmVector2 reactionForce;
		public FsmFloat reactionForceMagnitude;
		public FsmFloat reactionTorque;
	}
}
