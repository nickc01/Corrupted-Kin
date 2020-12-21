using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmObject : NamedVariable
	{
		[SerializeField]
		private string typeName;
		[SerializeField]
		private UnityEngine.Object value;
	}
}
