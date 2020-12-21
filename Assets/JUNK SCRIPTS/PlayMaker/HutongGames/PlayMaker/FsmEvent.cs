using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmEvent
	{
		[SerializeField]
		private string name;
		[SerializeField]
		private bool isSystemEvent;
		[SerializeField]
		private bool isGlobal;
	}
}
