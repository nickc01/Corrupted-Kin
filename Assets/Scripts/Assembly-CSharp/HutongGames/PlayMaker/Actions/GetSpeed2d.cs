using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetSpeed2d : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat storeResult;
		public bool everyFrame;
	}
}
