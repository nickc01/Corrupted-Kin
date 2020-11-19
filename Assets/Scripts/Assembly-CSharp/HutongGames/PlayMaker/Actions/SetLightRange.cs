using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightRange : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat lightRange;
		public bool everyFrame;
	}
}
