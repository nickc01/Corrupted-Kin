using UnityEngine;
using System;
using UnityEngine.Audio;

public class MenuStyles : MonoBehaviour
{
	[Serializable]
	public class MenuStyle
	{
		[Serializable]
		public class CameraCurves
		{
			public float saturation;
			public AnimationCurve redChannel;
			public AnimationCurve greenChannel;
			public AnimationCurve blueChannel;
		}

		public bool enabled;
		public string displayName;
		public GameObject styleObject;
		public CameraCurves cameraColorCorrection;
		public AudioMixerSnapshot musicSnapshot;
		public int titleIndex;
		public string unlockKey;
		public string[] achievementKeys;
		public float[] initialAudioVolumes;
	}

	[Serializable]
	public struct StyleSettings
	{
		public int styleIndex;
		public string autoChangeVersion;
	}

	[Serializable]
	public struct StyleSettingsPlatform
	{
		public RuntimePlatform platform;
		public MenuStyles.StyleSettings settings;
	}

	public MenuStyle[] styles;
	public StyleSettings StyleDefault;
	public StyleSettingsPlatform[] StylePlatforms;
	public SpriteRenderer blackSolid;
	public float fadeTime;
	public MenuStyleTitle title;
}
