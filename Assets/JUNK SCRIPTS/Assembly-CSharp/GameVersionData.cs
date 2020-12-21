using System;
using UnityEngine;

[Serializable]
public class GameVersionData : ScriptableObject
{
	[SerializeField]
	public GameVersion gameVersion;
	public string version;
}
