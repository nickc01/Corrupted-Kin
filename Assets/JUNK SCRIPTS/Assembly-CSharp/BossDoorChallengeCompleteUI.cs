using UnityEngine;
using System;
using UnityEngine.UI;

public class BossDoorChallengeCompleteUI : MonoBehaviour
{
	[Serializable]
	public class BindingIcon
	{
		public Image icon;
		public Sprite allUnlockedSprite;
		public GameObject[] flashEffects;
	}

	public float achievementShowDelay;
	public Animator animator;
	public float appearAnimDelay;
	public float appearEndWaitTime;
	public float bindingCapAnimDelay;
	public float bindingCapAppearDelay;
	public float completionCapAppearDelay;
	public float endAnimDelay;
	public AudioSource musicSource;
	public float musicDelay;
	public BindingIcon bindingCapNail;
	public BindingIcon bindingCapShell;
	public BindingIcon bindingCapCharm;
	public BindingIcon bindingCapSoul;
	public AudioSource audioSourcePrefab;
	public AudioEvent screenAppearSound;
	public AudioEvent bindingAppearSound;
	public float bindingAppearPitchIncrease;
	public AudioEvent bindingAllAppearSound;
	public AudioEvent coreAppearSound;
	public GameObject[] coreFlashEffects;
	public GameObject completeCore;
	public GameObject allBindingsCore;
	public GameObject noHitsCore;
	public GameObject allBindingsNoHitsCore;
	public CanvasGroup timerGroup;
	public float timerFadeDelay;
	public float timerFadeTime;
	public Text timerText;
}
