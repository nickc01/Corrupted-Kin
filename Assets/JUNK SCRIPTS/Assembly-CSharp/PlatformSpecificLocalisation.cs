using UnityEngine;
using System;

public class PlatformSpecificLocalisation : MonoBehaviour
{
	[Serializable]
	public struct PlatformKey
	{
		public RuntimePlatform platform;
		public string sheetTitle;
		public string textKey;
	}

	public PlatformKey[] platformKeys;
}
