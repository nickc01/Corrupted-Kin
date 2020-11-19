using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class DeviceOrientationEvent : FsmStateAction
	{
		public DeviceOrientation orientation;
		public FsmEvent sendEvent;
		public bool everyFrame;
	}
}
