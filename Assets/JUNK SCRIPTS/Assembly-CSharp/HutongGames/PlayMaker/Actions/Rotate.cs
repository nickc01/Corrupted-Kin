using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class Rotate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 vector;
		public FsmFloat xAngle;
		public FsmFloat yAngle;
		public FsmFloat zAngle;
		public Space space;
		public bool perSecond;
		public bool everyFrame;
		public bool lateUpdate;
		public bool fixedUpdate;
	}
}
