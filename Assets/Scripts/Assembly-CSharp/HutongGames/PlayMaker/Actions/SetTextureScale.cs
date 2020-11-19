using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetTextureScale : ComponentAction<Renderer>
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmString namedTexture;
		public FsmFloat scaleX;
		public FsmFloat scaleY;
		public bool everyFrame;
	}
}
