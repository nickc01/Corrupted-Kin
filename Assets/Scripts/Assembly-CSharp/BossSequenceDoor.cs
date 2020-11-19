using UnityEngine;
using System;
using System.Collections.Generic;

public class BossSequenceDoor : MonoBehaviour
{
	[Serializable]
	public struct Completion
	{
		public bool canUnlock;
		public bool unlocked;
		public bool completed;
		public bool allBindings;
		public bool noHits;
		public bool boundNail;
		public bool boundShell;
		public bool boundCharms;
		public bool boundSoul;
		public List<string> viewedBossSceneCompletions;
	}

	public string playerDataString;
	public BossSequence bossSequence;
	public string titleSuperKey;
	public string titleSuperSheet;
	public string titleMainKey;
	public string titleMainSheet;
	public string descriptionKey;
	public string descriptionSheet;
	public BossSequenceDoor[] requiredComplete;
	public GameObject completedDisplay;
	public GameObject completedAllDisplay;
	public GameObject completedNoHitsDisplay;
	public GameObject boundNailDisplay;
	public GameObject boundHeartDisplay;
	public GameObject boundCharmsDisplay;
	public GameObject boundSoulDisplay;
	public GameObject boundAllDisplay;
	public GameObject boundAllBackboard;
	public GameObject lockSet;
	public GameObject lockInteractPrompt;
	public GameObject cameraLock;
	public GameObject unlockedSet;
	public PlayMakerFSM challengeFSM;
	public GameObject dreamReturnGate;
	public bool doLockBreakSequence;
	public GameObject lockBreakAnticEffects;
	public GameObject lockBreakRumbleSound;
	public SpriteRenderer[] glowSprites;
	public Material spriteFlashMaterial;
	public SpriteRenderer[] fadeSprites;
	public AnimationCurve glowCurve;
	public ParticleSystem glowParticles;
	public float lockBreakAnticTime;
	public GameObject lockBreakEffects;
	public GameObject lockedUIPrefab;
}
