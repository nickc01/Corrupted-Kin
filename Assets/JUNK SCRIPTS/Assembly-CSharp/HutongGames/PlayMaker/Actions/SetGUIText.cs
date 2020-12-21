using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGUIText : ComponentAction<GUIText>
	{
		public FsmOwnerDefault gameObject;
		public FsmString text;
		public bool everyFrame;
	}
}
