using UnityEngine;
using System;

public class AchievementIDMap : ScriptableObject
{
	[Serializable]
	public class AchievementIDPair
	{
		[SerializeField]
		private string internalId;
		[SerializeField]
		private int serviceId;
	}

	[SerializeField]
	private AchievementIDPair[] pairs;
}
