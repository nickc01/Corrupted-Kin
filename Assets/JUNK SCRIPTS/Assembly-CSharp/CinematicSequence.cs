using UnityEngine.Audio;
using UnityEngine;

public class CinematicSequence : SkippableSequence
{
	[SerializeField]
	private AudioMixerSnapshot atmosSnapshot;
	[SerializeField]
	private float atmosSnapshotTransitionDuration;
	[SerializeField]
	private CinematicVideoReference videoReference;
	[SerializeField]
	private bool isLooping;
	[SerializeField]
	private MeshRenderer targetRenderer;
	[SerializeField]
	private MeshRenderer blankerRenderer;
}
