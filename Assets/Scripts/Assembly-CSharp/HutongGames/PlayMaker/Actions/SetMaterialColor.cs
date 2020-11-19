using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetMaterialColor : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmMaterial material;
		public FsmString namedColor;
		public FsmColor color;
		public bool everyFrame;
	}
}
