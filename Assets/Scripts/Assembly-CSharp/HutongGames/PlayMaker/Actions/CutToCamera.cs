using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class CutToCamera : FsmStateAction
	{
		public Camera camera;
		public bool makeMainCamera;
		public bool cutBackOnExit;
	}
}
