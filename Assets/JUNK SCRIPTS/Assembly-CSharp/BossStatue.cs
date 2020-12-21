using UnityEngine;
using System;

public class BossStatue : MonoBehaviour
{
	[Serializable]
	public struct BossUIDetails
	{
		public string nameKey;
		public string nameSheet;
		public string descriptionKey;
		public string descriptionSheet;
	}

	[Serializable]
	public struct Completion
	{
		public bool hasBeenSeen;
		public bool isUnlocked;
		public bool completedTier1;
		public bool completedTier2;
		public bool completedTier3;
		public bool seenTier3Unlock;
		public bool usingAltVersion;
	}

	public BossScene bossScene;
	public BossScene dreamBossScene;
	public string statueStatePD;
	public BossUIDetails bossDetails;
	public string dreamStatueStatePD;
	public BossUIDetails dreamBossDetails;
	public bool hasNoTiers;
	public bool dontCountCompletion;
	public bool isAlwaysUnlocked;
	public bool isAlwaysUnlockedDream;
	public float inspectCameraHeight;
	public bool isHidden;
	public PlayMakerFSM bossUIControlFSM;
	public GameObject[] disableIfLocked;
	public GameObject[] enableIfLocked;
	public BossStatueTrophyPlaque regularPlaque;
	public BossStatueTrophyPlaque altPlaqueL;
	public BossStatueTrophyPlaque altPlaqueR;
	public SpriteRenderer lockedPlaque;
	public GameObject dreamReturnGate;
	public TriggerEnterEvent lightTrigger;
	public CameraLockArea cameraLock;
	public GameObject statueDisplay;
	public GameObject statueDisplayAlt;
	public ParticleSystem statueShakeParticles;
	public ParticleSystem statueUpParticles;
	public AudioSource statueShakeLoop;
	public AudioSource audioSourcePrefab;
	public AudioEvent statueDownSound;
	public float statueDownSoundDelay;
	public AudioEvent statueUpSound;
	public float statueUpSoundDelay;
	public float swapWaitTime;
	public float shakeTime;
	public float holdTime;
	public float upParticleDelay;
}
