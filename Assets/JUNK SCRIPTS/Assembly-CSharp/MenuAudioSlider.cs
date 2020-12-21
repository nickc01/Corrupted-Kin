using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuAudioSlider : MonoBehaviour
{
	public enum AudioSettingType
	{
		MasterVolume = 0,
		MusicVolume = 1,
		SoundVolume = 2,
	}

	public Slider slider;
	public Text textUI;
	public AudioMixer masterMixer;
	public AudioSettingType audioSetting;
	[SerializeField]
	private float value;
}
