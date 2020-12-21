using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class FsmOwnerDefault
	{
		[SerializeField]
		private OwnerDefaultOption ownerOption;
		[SerializeField]
		private FsmGameObject gameObject;
	}
}
