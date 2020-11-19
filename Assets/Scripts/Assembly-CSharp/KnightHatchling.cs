using UnityEngine;
using System;

public class KnightHatchling : MonoBehaviour
{
	[Serializable]
	public struct TypeDetails
	{
		public int damage;
		public AudioEvent birthSound;
		public Color spatterColor;
		public bool dung;
		public Transform groundPoint;
		public string attackAnim;
		public string flyAnim;
		public string hatchAnim;
		public string teleEndAnim;
		public string teleStartAnim;
		public string turnAttackAnim;
		public string turnFlyAnim;
		public string restStartAnim;
		public string restEndAnim;
	}

	public TriggerEnterEvent enemyRange;
	public TriggerEnterEvent groundRange;
	public Collider2D terrainCollider;
	public TypeDetails normalDetails;
	public TypeDetails dungDetails;
	public ParticleSystem dungPt;
	public AudioClip[] loopClips;
	public AudioClip attackChargeClip;
	public AudioSource audioSourcePrefab;
	public AudioEvent explodeSound;
	public AudioEvent dungExplodeSound;
	public AudioEventRandom dungSleepPlopSound;
	public GameObject dungExplosionPrefab;
	public DamageEnemies damageEnemies;
}
