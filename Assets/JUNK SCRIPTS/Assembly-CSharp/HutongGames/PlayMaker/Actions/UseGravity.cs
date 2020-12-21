using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class UseGravity : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmBool useGravity;
	}
}
