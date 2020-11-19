using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetCameraFOV : ComponentAction<Camera>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat fieldOfView;
		public bool everyFrame;
	}
}
