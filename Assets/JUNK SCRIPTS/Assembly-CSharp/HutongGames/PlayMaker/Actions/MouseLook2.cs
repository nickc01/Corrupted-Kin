using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MouseLook2 : ComponentAction<Rigidbody>
	{
		public enum RotationAxes
		{
			MouseXAndY = 0,
			MouseX = 1,
			MouseY = 2,
		}

		public FsmOwnerDefault gameObject;
		public RotationAxes axes;
		public FsmFloat sensitivityX;
		public FsmFloat sensitivityY;
		public FsmFloat minimumX;
		public FsmFloat maximumX;
		public FsmFloat minimumY;
		public FsmFloat maximumY;
		public bool everyFrame;
	}
}
