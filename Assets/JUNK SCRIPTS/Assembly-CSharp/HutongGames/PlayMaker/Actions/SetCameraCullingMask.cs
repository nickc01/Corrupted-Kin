using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetCameraCullingMask : ComponentAction<Camera>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt[] cullingMask;
		public FsmBool invertMask;
		public bool everyFrame;
	}
}
