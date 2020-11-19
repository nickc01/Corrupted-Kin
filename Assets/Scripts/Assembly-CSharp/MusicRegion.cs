using UnityEngine;
using UnityEngine.Audio;

public class MusicRegion : MonoBehaviour
{
	public bool dirtmouth;
	public bool minesDelay;
	public MusicCue enterMusicCue;
	public AudioMixerSnapshot enterMusicSnapshot;
	public string enterTrackEvent;
	public float enterTransitionTime;
	public MusicCue exitMusicCue;
	public AudioMixerSnapshot exitMusicSnapshot;
	public string exitTrackEvent;
	public float exitTransitionTime;
}
