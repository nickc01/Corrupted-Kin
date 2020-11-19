using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGravity2dScale : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat gravityScale;
	}
}
