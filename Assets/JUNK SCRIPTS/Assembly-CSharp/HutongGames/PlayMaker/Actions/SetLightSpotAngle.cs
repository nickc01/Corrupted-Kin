using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightSpotAngle : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat lightSpotAngle;
		public bool everyFrame;
	}
}
