using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGUITextureAlpha : ComponentAction<GUITexture>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat alpha;
		public bool everyFrame;
	}
}
