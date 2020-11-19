using UnityEngine;

public class EnemyHitEffectsUninfected : MonoBehaviour
{
	public Vector3 effectOrigin;
	public AudioSource audioPlayerPrefab;
	public AudioEvent enemyDamage;
	public GameObject uninfectedHitPt;
	public GameObject slashEffectGhost1;
	public GameObject slashEffectGhost2;
	public bool sendDamageFlashEvent;
}
