using System;
using UnityEngine;
using GlobalEnums;
using UnityEngine.Audio;

[Serializable]
public class SceneManager : MonoBehaviour
{
	public SceneType sceneType;
	public MapZone mapZone;
	public bool isWindy;
	public bool isTremorZone;
	public int environmentType;
	public int darknessLevel;
	public bool noLantern;
	public float saturation;
	public bool ignorePlatformSaturationModifiers;
	public AnimationCurve redChannel;
	public AnimationCurve greenChannel;
	public AnimationCurve blueChannel;
	public Color defaultColor;
	public float defaultIntensity;
	public Color heroLightColor;
	public bool noParticles;
	public MapZone overrideParticlesWith;
	[SerializeField]
	private AtmosCue atmosCue;
	[SerializeField]
	private MusicCue musicCue;
	[SerializeField]
	private MusicCue infectedMusicCue;
	[SerializeField]
	private AudioMixerSnapshot musicSnapshot;
	[SerializeField]
	private float musicDelayTime;
	[SerializeField]
	private float musicTransitionTime;
	public AudioMixerSnapshot atmosSnapshot;
	public AudioMixerSnapshot enviroSnapshot;
	public AudioMixerSnapshot actorSnapshot;
	public AudioMixerSnapshot shadeSnapshot;
	public float transitionTime;
	public GameObject borderPrefab;
	public bool manualMapTrigger;
	public GameObject hollowShadeObject;
	public GameObject dreamgateObject;
}
