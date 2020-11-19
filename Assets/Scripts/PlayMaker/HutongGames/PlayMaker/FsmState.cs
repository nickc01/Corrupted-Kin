using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmState
	{
		[SerializeField]
		private string name;
		[SerializeField]
		private string description;
		[SerializeField]
		private byte colorIndex;
		[SerializeField]
		private Rect position;
		[SerializeField]
		private bool isBreakpoint;
		[SerializeField]
		private bool isSequence;
		[SerializeField]
		private bool hideUnused;
		[SerializeField]
		private FsmTransition[] transitions;
		[SerializeField]
		private ActionData actionData;
	}
}
