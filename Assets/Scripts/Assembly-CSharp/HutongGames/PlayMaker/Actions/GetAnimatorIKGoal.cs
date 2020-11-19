using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAnimatorIKGoal : FsmStateActionAnimatorBase
	{
		public FsmOwnerDefault gameObject;
		public FsmEnum iKGoal;
		public FsmGameObject goal;
		public FsmVector3 position;
		public FsmQuaternion rotation;
		public FsmFloat positionWeight;
		public FsmFloat rotationWeight;
	}
}
