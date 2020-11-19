using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class NamedVariable
	{
		[SerializeField]
		private bool useVariable;
		[SerializeField]
		private string name;
		[SerializeField]
		private string tooltip;
		[SerializeField]
		private bool showInInspector;
		[SerializeField]
		private bool networkSync;
	}
}
