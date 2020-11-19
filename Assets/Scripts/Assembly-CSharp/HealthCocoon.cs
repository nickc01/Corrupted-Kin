using UnityEngine;
using System;

public class HealthCocoon : MonoBehaviour
{
	[Serializable]
	public class FlingPrefab
	{
		public GameObject prefab;
		public int minAmount;
		public int maxAmount;
		public Vector2 originVariation;
		public float minSpeed;
		public float maxSpeed;
		public float minAngle;
		public float maxAngle;
	}

	public GameObject[] slashEffects;
	public GameObject[] spellEffects;
	public Vector3 effectOrigin;
	public FlingPrefab[] flingPrefabs;
	public GameObject[] enableChildren;
	public GameObject[] disableChildren;
	public Collider2D[] disableColliders;
	public Rigidbody2D cap;
	public float capHitForce;
	public AudioClip deathSound;
	public string idleAnimation;
	public string sweatAnimation;
	public AudioClip moveSound;
	public float waitMin;
	public float waitMax;
}
