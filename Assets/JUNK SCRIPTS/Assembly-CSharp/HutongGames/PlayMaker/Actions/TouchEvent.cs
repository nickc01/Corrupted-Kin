using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class TouchEvent : FsmStateAction
	{
		public FsmInt fingerId;
		public TouchPhase touchPhase;
		public FsmEvent sendEvent;
		public FsmInt storeFingerId;
	}
}
