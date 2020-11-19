using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmQuaternion : NamedVariable
	{
		[SerializeField]
		private Quaternion value;
	}
}
