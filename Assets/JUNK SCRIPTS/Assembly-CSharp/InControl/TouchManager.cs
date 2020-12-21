using UnityEngine;

namespace InControl
{
	public class TouchManager : SingletonMonoBehavior<TouchManager, InControlManager>
	{
		public enum GizmoShowOption
		{
			Never = 0,
			WhenSelected = 1,
			UnlessPlaying = 2,
			Always = 3,
		}

		public Camera touchCamera;
		public GizmoShowOption controlsShowGizmos;
		public bool enableControlsOnTouch;
		[SerializeField]
		private bool _controlsEnabled;
		public int controlsLayer;
	}
}
