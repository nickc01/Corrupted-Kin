using UnityEngine;
using UnityEngine.Audio;

public class AtmosCue : ScriptableObject
{
	[SerializeField]
	private AudioMixerSnapshot snapshot;
	[SerializeField]
	private bool[] isChannelEnabled;
}
