using UnityEngine;
using System;

public class WorldInfo : ScriptableObject
{
	[Serializable]
	public struct TransitionInfo
	{
		public string DoorName;
		public string DestinationSceneName;
		public string DestinationDoorName;
	}

	[Serializable]
	public class SceneInfo
	{
		public string SceneName;
		public WorldInfo.TransitionInfo[] Transitions;
		public int ZoneTags;
	}

	public SceneInfo[] Scenes;
}
