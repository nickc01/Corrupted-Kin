using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetDrag : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat drag;
		public bool everyFrame;
	}
}
