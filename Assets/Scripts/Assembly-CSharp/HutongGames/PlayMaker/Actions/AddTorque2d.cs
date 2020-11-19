using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddTorque2d : ComponentAction<Rigidbody2D>
	{
		public FsmOwnerDefault gameObject;
		public ForceMode2D forceMode;
		public FsmFloat torque;
		public bool everyFrame;
	}
}
