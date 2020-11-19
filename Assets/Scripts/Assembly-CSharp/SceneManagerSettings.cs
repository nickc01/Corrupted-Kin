using System;
using GlobalEnums;
using UnityEngine;

[Serializable]
public class SceneManagerSettings
{
	[SerializeField]
	public MapZone mapZone;
	[SerializeField]
	public Color defaultColor;
	public float defaultIntensity;
	public float saturation;
	[SerializeField]
	public AnimationCurve redChannel;
	[SerializeField]
	public AnimationCurve greenChannel;
	[SerializeField]
	public AnimationCurve blueChannel;
	[SerializeField]
	public Color heroLightColor;
}
