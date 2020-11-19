using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddRelativeForce2d : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public ForceMode2D forceMode;
		public FsmVector2 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmVector3 vector3;
		public bool everyFrame;
	}
}
