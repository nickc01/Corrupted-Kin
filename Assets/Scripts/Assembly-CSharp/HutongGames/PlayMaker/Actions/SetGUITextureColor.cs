using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGUITextureColor : ComponentAction<GUITexture>
	{
		public FsmOwnerDefault gameObject;
		public FsmColor color;
		public bool everyFrame;
	}
}
