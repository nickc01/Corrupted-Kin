using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Blink : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat timeOff;
		public FsmFloat timeOn;
		public FsmBool startOn;
		public bool rendererOnly;
		public bool realTime;
	}
}
