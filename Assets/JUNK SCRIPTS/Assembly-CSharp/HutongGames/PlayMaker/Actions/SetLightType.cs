using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetLightType : ComponentAction<Light>
	{
		public FsmOwnerDefault gameObject;
		public FsmEnum lightType;
	}
}
