using System;
using UnityEngine;

public class MenuButtonListPlatformCondition : MenuButtonListCondition
{
	[Serializable]
	public struct PlatformBoolPair
	{
		public RuntimePlatform platform;
		public bool activate;
	}

	public PlatformBoolPair[] platforms;
	public bool defaultActivation;
}
