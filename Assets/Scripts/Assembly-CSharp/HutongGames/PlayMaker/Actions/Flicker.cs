using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Flicker : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat frequency;
		public FsmFloat amountOn;
		public bool rendererOnly;
		public bool realTime;
	}
}
