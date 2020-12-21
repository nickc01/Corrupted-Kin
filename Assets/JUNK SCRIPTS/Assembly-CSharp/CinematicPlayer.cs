using UnityEngine;
using GlobalEnums;
using UnityEngine.Audio;

public class CinematicPlayer : MonoBehaviour
{
	public enum MovieTrigger
	{
		ON_START = 0,
		MANUAL_TRIGGER = 1,
	}

	public enum FadeInSpeed
	{
		NORMAL = 0,
		SLOW = 1,
		NONE = 2,
	}

	public enum FadeOutSpeed
	{
		NORMAL = 0,
		SLOW = 1,
		NONE = 2,
	}

	public enum VideoType
	{
		OpeningCutscene = 0,
		StagTravel = 1,
		InGameVideo = 2,
		OpeningPrologue = 3,
		EndingA = 4,
		EndingB = 5,
		EndingC = 6,
		EndingGG = 7,
	}

	[SerializeField]
	private CinematicVideoReference videoClip;
	[SerializeField]
	private AudioSource additionalAudio;
	[SerializeField]
	private bool additionalAudioContinuesPastVideo;
	[SerializeField]
	private MeshRenderer selfBlanker;
	public MovieTrigger playTrigger;
	public FadeInSpeed fadeInSpeed;
	public float delayBeforeFadeIn;
	public SkipPromptMode skipMode;
	public bool startSkipLocked;
	public FadeOutSpeed fadeOutSpeed;
	public bool loopVideo;
	public VideoType videoType;
	public CinematicVideoFaderStyles faderStyle;
	[SerializeField]
	private AudioMixerSnapshot masterOff;
	[SerializeField]
	private AudioMixerSnapshot masterResume;
}
