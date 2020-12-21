using UnityEngine;
using UnityEngine.Audio;

public class EnemyDeathEffects : MonoBehaviour
{
	[SerializeField]
	private GameObject corpsePrefab;
	[SerializeField]
	private bool corpseFacesRight;
	[SerializeField]
	private float corpseFlingSpeed;
	[SerializeField]
	public Vector3 corpseSpawnPoint;
	[SerializeField]
	private string deathBroadcastEvent;
	[SerializeField]
	public Vector3 effectOrigin;
	[SerializeField]
	private bool lowCorpseArc;
	[SerializeField]
	private string playerDataName;
	[SerializeField]
	private bool recycle;
	[SerializeField]
	private bool rotateCorpse;
	[SerializeField]
	private AudioMixerSnapshot audioSnapshotOnDeath;
	[SerializeField]
	private GameObject journalUpdateMessagePrefab;
	[SerializeField]
	private EnemyDeathTypes enemyDeathType;
	[SerializeField]
	protected AudioSource audioPlayerPrefab;
	[SerializeField]
	protected AudioEvent enemyDeathSwordAudio;
	[SerializeField]
	protected AudioEvent enemyDamageAudio;
	[SerializeField]
	protected AudioClip enemyDeathSwordClip;
	[SerializeField]
	protected AudioClip enemyDamageClip;
	[SerializeField]
	protected GameObject deathWaveInfectedPrefab;
	[SerializeField]
	protected GameObject deathWaveInfectedSmallPrefab;
	[SerializeField]
	protected GameObject spatterOrangePrefab;
	[SerializeField]
	protected GameObject deathPuffMedPrefab;
	[SerializeField]
	protected GameObject deathPuffLargePrefab;
	[SerializeField]
	protected GameObject dreamEssenceCorpseGetPrefab;
	public bool doKillFreeze;
}
