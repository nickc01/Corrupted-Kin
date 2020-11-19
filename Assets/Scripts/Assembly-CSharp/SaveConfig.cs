using System;
using UnityEngine;

[Serializable]
public class SaveConfig : ScriptableObject
{
	public enum SaveSet
	{
		Default = 0,
		Test = 1,
		Full = 2,
	}

	[SerializeField]
	public SaveSet saveToUse;
	[SerializeField]
	public PlayerData defaultPlayerData;
	[SerializeField]
	public PlayerData testPlayerData;
	[SerializeField]
	public PlayerData fullPlayerData;
}
