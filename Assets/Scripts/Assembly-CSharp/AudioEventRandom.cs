using System;
using UnityEngine;

[Serializable]
public struct AudioEventRandom
{
	public AudioClip[] Clips;
	public float PitchMin;
	public float PitchMax;
	public float Volume;
}
