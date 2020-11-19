using UnityEngine;
using System;
using UnityEngine.Audio;

public class HealthManager : MonoBehaviour
{
	[Serializable]
	private struct HPScaleGG
	{
		public int level1;
		public int level2;
		public int level3;
	}

	[SerializeField]
	private AudioSource audioPlayerPrefab;
	[SerializeField]
	private AudioEvent regularInvincibleAudio;
	[SerializeField]
	private GameObject blockHitPrefab;
	[SerializeField]
	private GameObject strikeNailPrefab;
	[SerializeField]
	private GameObject slashImpactPrefab;
	[SerializeField]
	private GameObject fireballHitPrefab;
	[SerializeField]
	private GameObject sharpShadowImpactPrefab;
	[SerializeField]
	private GameObject corpseSplatPrefab;
	[SerializeField]
	private AudioEvent enemyDeathSwordAudio;
	[SerializeField]
	private AudioEvent enemyDamageAudio;
	[SerializeField]
	private GameObject smallGeoPrefab;
	[SerializeField]
	private GameObject mediumGeoPrefab;
	[SerializeField]
	private GameObject largeGeoPrefab;
	[SerializeField]
	public int hp;
	[SerializeField]
	private int enemyType;
	[SerializeField]
	private Vector3 effectOrigin;
	[SerializeField]
	private bool ignoreKillAll;
	[SerializeField]
	private HPScaleGG hpScale;
	[SerializeField]
	private GameObject battleScene;
	[SerializeField]
	private GameObject sendHitTo;
	[SerializeField]
	private GameObject sendKilledToObject;
	[SerializeField]
	private string sendKilledToName;
	[SerializeField]
	private int smallGeoDrops;
	[SerializeField]
	private int mediumGeoDrops;
	[SerializeField]
	private int largeGeoDrops;
	[SerializeField]
	private bool megaFlingGeo;
	[SerializeField]
	private bool hasAlternateHitAnimation;
	[SerializeField]
	private string alternateHitAnimation;
	[SerializeField]
	private bool invincible;
	[SerializeField]
	private int invincibleFromDirection;
	[SerializeField]
	private bool preventInvincibleEffect;
	[SerializeField]
	private bool hasAlternateInvincibleSound;
	[SerializeField]
	private AudioClip alternateInvincibleSound;
	[SerializeField]
	private AudioMixerSnapshot deathAudioSnapshot;
	[SerializeField]
	public bool hasSpecialDeath;
	[SerializeField]
	public bool deathReset;
	[SerializeField]
	public bool damageOverride;
	[SerializeField]
	private bool ignoreAcid;
	[SerializeField]
	private bool showGodfinderIcon;
	[SerializeField]
	private float showGodFinderDelay;
	[SerializeField]
	private BossScene unlockBossScene;
	[SerializeField]
	private bool ignoreHazards;
	[SerializeField]
	private bool ignoreWater;
	[SerializeField]
	private float invulnerableTime;
	[SerializeField]
	private bool semiPersistent;
	public bool isDead;
}
