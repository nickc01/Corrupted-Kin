using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetVelocity2d : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 vector;
		public FsmFloat x;
		public FsmFloat y;
		public Space space;
		public bool everyFrame;
	}
}
