using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetVisibility : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmBool toggle;
		public FsmBool visible;
		public bool resetOnExit;
	}
}
