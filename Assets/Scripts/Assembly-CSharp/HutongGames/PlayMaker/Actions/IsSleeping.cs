using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class IsSleeping : ComponentAction<Rigidbody>
	{
		public FsmOwnerDefault gameObject;
		public FsmEvent trueEvent;
		public FsmEvent falseEvent;
		public FsmBool store;
		public bool everyFrame;
	}
}
