using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetMass : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat mass;
	}
}
