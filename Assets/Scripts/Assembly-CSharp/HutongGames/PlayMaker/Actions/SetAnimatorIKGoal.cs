using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorIKGoal : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public AvatarIKGoal iKGoal;
		public FsmGameObject goal;
		public FsmVector3 position;
		public FsmQuaternion rotation;
		public FsmFloat positionWeight;
		public FsmFloat rotationWeight;
		public bool everyFrame;
	}
}
