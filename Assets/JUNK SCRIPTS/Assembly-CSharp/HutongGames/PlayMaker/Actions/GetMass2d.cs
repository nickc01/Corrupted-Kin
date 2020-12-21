using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMass2d : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat storeResult;
	}
}
