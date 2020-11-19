using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMass : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat storeResult;
	}
}
