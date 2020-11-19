using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Ecosystem.Utils
{
	[Serializable]
	public class PlayMakerEventTarget
	{
		public ProxyEventTarget eventTarget;
		public GameObject gameObject;
		public bool includeChildren;
		public PlayMakerFSM fsmComponent;
	}
}
