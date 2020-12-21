using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmTransition
	{
		public enum CustomLinkStyle : byte
		{
			Default = 0,
			Bezier = 1,
			Circuit = 2,
		}

		public enum CustomLinkConstraint : byte
		{
			None = 0,
			LockLeft = 1,
			LockRight = 2,
		}

		[SerializeField]
		private FsmEvent fsmEvent;
		[SerializeField]
		private string toState;
		[SerializeField]
		private CustomLinkStyle linkStyle;
		[SerializeField]
		private CustomLinkConstraint linkConstraint;
		[SerializeField]
		private byte colorIndex;
	}
}
