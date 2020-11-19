using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddForce : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 atPosition;
		public FsmVector3 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		public Space space;
		public ForceMode forceMode;
		public bool everyFrame;
	}
}
