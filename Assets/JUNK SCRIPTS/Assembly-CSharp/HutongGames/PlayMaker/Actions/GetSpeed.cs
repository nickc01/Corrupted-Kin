using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetSpeed : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
