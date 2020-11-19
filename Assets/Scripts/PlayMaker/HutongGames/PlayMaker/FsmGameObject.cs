using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmGameObject : NamedVariable
	{
		[SerializeField]
		private GameObject value;
	}
}
