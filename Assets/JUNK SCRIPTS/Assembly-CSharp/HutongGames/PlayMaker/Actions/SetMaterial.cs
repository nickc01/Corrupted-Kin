using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetMaterial : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmMaterial material;
	}
}
