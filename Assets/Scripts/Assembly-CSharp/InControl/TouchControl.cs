using UnityEngine;

namespace InControl
{
	public class TouchControl : MonoBehaviour
	{
		public enum ButtonTarget
		{
			None = 0,
			DPadDown = 12,
			DPadLeft = 13,
			DPadRight = 14,
			DPadUp = 11,
			LeftTrigger = 15,
			RightTrigger = 16,
			LeftBumper = 17,
			RightBumper = 18,
			Action1 = 19,
			Action2 = 20,
			Action3 = 21,
			Action4 = 22,
			Action5 = 23,
			Action6 = 24,
			Action7 = 25,
			Action8 = 26,
			Action9 = 27,
			Action10 = 28,
			Action11 = 29,
			Action12 = 30,
			Menu = 106,
			Button0 = 500,
			Button1 = 501,
			Button2 = 502,
			Button3 = 503,
			Button4 = 504,
			Button5 = 505,
			Button6 = 506,
			Button7 = 507,
			Button8 = 508,
			Button9 = 509,
			Button10 = 510,
			Button11 = 511,
			Button12 = 512,
			Button13 = 513,
			Button14 = 514,
			Button15 = 515,
			Button16 = 516,
			Button17 = 517,
			Button18 = 518,
			Button19 = 519,
		}

		public enum AnalogTarget
		{
			None = 0,
			LeftStick = 1,
			RightStick = 2,
			Both = 3,
		}

		public enum SnapAngles
		{
			None = 0,
			Four = 4,
			Eight = 8,
			Sixteen = 16,
		}

	}
}
