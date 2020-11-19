using System;
using UnityEngine;
using System.Collections.Generic;

namespace TeamCherry
{
	[Serializable]
	public class SceneDefaultSettings : ScriptableObject
	{
		[SerializeField]
		public int selection;
		[SerializeField]
		public List<SceneManagerSettings> settingsList;
	}
}
