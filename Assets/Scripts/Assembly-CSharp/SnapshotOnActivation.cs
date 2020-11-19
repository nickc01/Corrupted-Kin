using UnityEngine;
using UnityEngine.Audio;

public class SnapshotOnActivation : MonoBehaviour
{
	public AudioMixerSnapshot activationSnapshot;
	public AudioMixerSnapshot deactivationSnapshot;
	public float transitionTime;
}
