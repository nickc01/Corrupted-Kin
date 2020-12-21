using System;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmEventTarget
	{
		public enum EventTarget
		{
			Self = 0,
			GameObject = 1,
			GameObjectFSM = 2,
			FSMComponent = 3,
			BroadcastAll = 4,
			HostFSM = 5,
			SubFSMs = 6,
		}

		public EventTarget target;
		public FsmBool excludeSelf;
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmBool sendToChildren;
		public PlayMakerFSM fsmComponent;
	}
}
