using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightIntensity : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat lightIntensity;
		public bool everyFrame;
	}
}
