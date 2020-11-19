using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetIsKinematic : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isKinematic;
	}
}
