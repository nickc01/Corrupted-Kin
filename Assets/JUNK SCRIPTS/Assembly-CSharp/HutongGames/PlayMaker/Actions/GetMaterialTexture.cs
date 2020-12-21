using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMaterialTexture : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmString namedTexture;
		public FsmTexture storedTexture;
		public bool getFromSharedMaterial;
	}
}
