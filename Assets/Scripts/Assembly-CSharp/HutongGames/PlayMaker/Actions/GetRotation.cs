using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRotation : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmQuaternion quaternion;
		public FsmVector3 vector;
		public FsmFloat xAngle;
		public FsmFloat yAngle;
		public FsmFloat zAngle;
		public Space space;
		public bool everyFrame;
	}
}
