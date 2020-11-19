using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AddExplosionForce : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 center;
		public FsmFloat force;
		public FsmFloat radius;
		public FsmFloat upwardsModifier;
		public ForceMode forceMode;
		public bool everyFrame;
	}
}
