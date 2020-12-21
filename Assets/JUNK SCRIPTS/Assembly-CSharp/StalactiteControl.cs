using UnityEngine;

public class StalactiteControl : MonoBehaviour
{
	public GameObject top;
	public float startFallOffset;
	public GameObject startFallEffect;
	public AudioClip startFallSound;
	public float fallDelay;
	public GameObject fallEffect;
	public GameObject trailEffect;
	public GameObject nailStrikePrefab;
	public GameObject embeddedVersion;
	public GameObject[] landEffectPrefabs;
	public float hitVelocity;
	public GameObject[] hitUpEffectPrefabs;
	public AudioClip hitSound;
	public GameObject hitUpRockPrefabs;
	public int spawnMin;
	public int spawnMax;
	public int speedMin;
	public int speedMax;
	public AudioClip breakSound;
}
