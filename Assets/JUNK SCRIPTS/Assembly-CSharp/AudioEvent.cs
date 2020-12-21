using System;
using UnityEngine;

[Serializable]
public struct AudioEvent
{
	public AudioClip Clip;
	public float PitchMin;
	public float PitchMax;
	public float Volume;
}
