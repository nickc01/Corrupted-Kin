using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightCookie : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmTexture lightCookie;
	}
}
