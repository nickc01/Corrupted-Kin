using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetMaterialFloat : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmMaterial material;
		public FsmString namedFloat;
		public FsmFloat floatValue;
		public bool everyFrame;
	}
}
