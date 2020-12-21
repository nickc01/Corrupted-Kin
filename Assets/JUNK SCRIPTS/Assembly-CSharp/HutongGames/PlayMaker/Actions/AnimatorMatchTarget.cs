using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimatorMatchTarget : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public AvatarTarget bodyPart;
		public FsmGameObject target;
		public FsmVector3 targetPosition;
		public FsmQuaternion targetRotation;
		public FsmVector3 positionWeight;
		public FsmFloat rotationWeight;
		public FsmFloat startNormalizedTime;
		public FsmFloat targetNormalizedTime;
		public bool everyFrame;
	}
}
