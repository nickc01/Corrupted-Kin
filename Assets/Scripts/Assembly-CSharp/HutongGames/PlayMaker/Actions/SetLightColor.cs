using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightColor : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmColor lightColor;
		public bool everyFrame;
	}
}
