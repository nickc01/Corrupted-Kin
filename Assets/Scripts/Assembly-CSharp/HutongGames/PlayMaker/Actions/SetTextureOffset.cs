using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTextureOffset : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmString namedTexture;
		public FsmFloat offsetX;
		public FsmFloat offsetY;
		public bool everyFrame;
	}
}
