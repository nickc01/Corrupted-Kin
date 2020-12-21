using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetShadowStrength : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat shadowStrength;
		public bool everyFrame;
	}
}
