using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightFlare : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public Flare lightFlare;
	}
}
