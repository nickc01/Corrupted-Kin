using System;
using UnityEngine;

[Serializable]
public class GradeMarker : MonoBehaviour
{
	public bool enableGrade;
	public float maxIntensityRadius;
	public float cutoffRadius;
	public float saturation;
	public AnimationCurve redChannel;
	public AnimationCurve greenChannel;
	public AnimationCurve blueChannel;
	public float ambientIntensity;
	public Color ambientColor;
	public Color heroLightColor;
	public float easeDuration;
}
