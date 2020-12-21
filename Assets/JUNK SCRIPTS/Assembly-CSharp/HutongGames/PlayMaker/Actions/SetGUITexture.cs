using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGUITexture : ComponentAction<GUITexture>
	{
		public FsmOwnerDefault gameObject;
		public FsmTexture texture;
	}
}
