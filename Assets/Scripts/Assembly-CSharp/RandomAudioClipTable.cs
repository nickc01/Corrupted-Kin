using UnityEngine;
using System;

public class RandomAudioClipTable : ScriptableObject
{
	[Serializable]
	private struct Option
	{
		public AudioClip Clip;
		public float Weight;
	}

	[SerializeField]
	private Option[] options;
	[SerializeField]
	private float pitchMin;
	[SerializeField]
	private float pitchMax;
}
