using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetBackgroundColor : ComponentAction<Camera>
	{
		public FsmOwnerDefault gameObject;
		public FsmColor backgroundColor;
		public bool everyFrame;
	}
}
