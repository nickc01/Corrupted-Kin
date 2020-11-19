using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmEnum : NamedVariable
	{
		[SerializeField]
		private string enumName;
		[SerializeField]
		private int intValue;
	}
}
